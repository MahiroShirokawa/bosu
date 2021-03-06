﻿using osu.Framework.Graphics.Textures;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osu.Framework.Graphics;

namespace osu.Game.Rulesets.Bosu.UI
{
    public class BosuPlayfieldBorder : Sprite
    {
        public BosuPlayfieldBorder()
        {
            Size = BosuPlayfield.BASE_SIZE + Vector2.One;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Texture = textures.Get("Playfield/border");
        }
    }
}
