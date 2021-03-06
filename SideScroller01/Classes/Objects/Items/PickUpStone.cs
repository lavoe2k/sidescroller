﻿using System;
using Microsoft.Xna.Framework;
using SideScroller01.Classes.Scene;

namespace SideScroller01.Classes.Objects.Items
{
    class PickUpStone : GameItem
    {
        public PickUpStone(Level inLevel, Vector2 startPos)
            : base(startPos, inLevel, null)
        {
            this.Sprite = TextureManager.GetTexure("Rocks");
            this.InitSpriteFrames(this.Sprite.Width, this.Sprite.Height);
            this.SetOriginPosition();
            this.GetLayerDepth(this.Position.Y);
        }

        public override void GetPickedUp(Player p)
        {
            p.GetStone();

            base.GetPickedUp(p);
        }

        public override bool CheckCollision(Actor actor)
        {
            // 1) Are wer within Y Range
            if (actor.Position.Y > this.Position.Y - Actor.HIT_Y_RANGE
                && actor.Position.Y < this.Position.Y + Actor.HIT_Y_RANGE)
            {
                // 2) Are we touching
                float dist = Math.Abs(actor.Position.X - this.Position.X); // Distance from Player
                float minDist = this.HitArea + actor.HitArea; // Minimum distance for a collision

                if (dist < minDist) return true; // Collision detected

            }

            // No Collision
            return false;
        }
    }
}
