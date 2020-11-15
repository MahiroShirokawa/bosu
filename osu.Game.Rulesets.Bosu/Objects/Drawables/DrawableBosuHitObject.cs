﻿using osu.Game.Rulesets.Bosu.UI.Objects.Playfield.Player;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Bosu.Objects.Drawables
{
    public abstract class DrawableBosuHitObject : DrawableHitObject<BosuHitObject>
    {
        protected BosuPlayer Player;

        protected DrawableBosuHitObject(BosuHitObject hitObject)
            : base(hitObject)
        {
        }

        protected sealed override double InitialLifetimeOffset => HitObject.TimePreempt;

        public void GetPlayerToTrace(BosuPlayer player) => Player = player;
    }
}
