﻿using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Utils;
using osu.Game.Rulesets.Bosu.UI.Objects.Playfield.Player;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Bosu.UI.Objects.Playfield
{
    public class DeathOverlay : CompositeDrawable
    {
        private const int particle_count = 30;

        private SampleChannel deathSound;

        private readonly BosuPlayer player;
        private readonly Container<DeathParticle> particlesContainer;
        private readonly Box tint;
        private readonly Sprite failSprite;
        private readonly Sprite deathCircle;

        public DeathOverlay(BosuPlayer player)
        {
            this.player = player;

            RelativeSizeAxes = Axes.Both;
            InternalChildren = new Drawable[]
            {
                particlesContainer = new Container<DeathParticle>
                {
                    RelativeSizeAxes = Axes.Both,
                    Masking = true,
                },
                deathCircle = new Sprite
                {
                    Size = new Vector2(85),
                    Scale = Vector2.Zero,
                    AlwaysPresent = true,
                    Origin = Anchor.Centre
                },
                tint = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0,
                    Colour = Color4.Red,
                },
                failSprite = new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Width = 0.8f,
                    Alpha = 0,
                    FillMode = FillMode.Fit,
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures, ISampleStore samples)
        {
            failSprite.Texture = textures.Get("game-over");
            deathSound = samples.Get("death");
            deathCircle.Texture = textures.Get("death-circle");
        }

        public void OnDeath()
        {
            var position = player.PlayerPosition();

            for (int i = 0; i < particle_count; i++)
            {
                var particle = new DeathParticle
                {
                    Origin = Anchor.Centre,
                    Position = position
                };

                particlesContainer.Add(particle);

                particle.MoveToOffset(new Vector2(RNG.Next(-150, 150), RNG.Next(-150, 150)), 2000, Easing.Out);
                particle.FadeOut(2000, Easing.OutQuint);
            }

            player.Player.FadeOut();

            deathCircle.Position = position;
            deathCircle.ScaleTo(Vector2.One, 1500, Easing.OutQuint);
            deathCircle.FadeOut(600);

            tint.FadeTo(0.6f, 2000, Easing.OutQuint);
            failSprite.FadeTo(1, 1000, Easing.OutQuint);
            deathSound.Play();
        }
    }
}
