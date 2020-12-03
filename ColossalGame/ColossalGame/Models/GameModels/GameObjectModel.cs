﻿using System;
using System.Linq;
using tainicom.Aether.Physics2D.Common;
using tainicom.Aether.Physics2D.Dynamics;

namespace ColossalGame.Models.GameModels
{
    public class GameObjectModel
    {
        public int ID { get; }
        public Body ObjectBody { get; set; }

        public float ConversionFactor { get; set; } = 64f;

        public float Radius
        {
            get => ObjectBody.FixtureList.First().Shape.Radius * ConversionFactor;
            set => ObjectBody.FixtureList.First().Shape.Radius = value/ConversionFactor;
        }

        public GameObjectModel(Body b)
        {
            var rnd = new Random();
            ObjectBody = b;
            ID = rnd.Next(1, 100000000);
        }

        public float YPos
        {
            get => ObjectBody.WorldCenter.Y*ConversionFactor;
            set => ObjectBody.SetTransform(new Vector2(XPos,value),ObjectBody.Rotation);
        }

        public float XPos
        {
            get => ObjectBody.WorldCenter.X*ConversionFactor;
            set => ObjectBody.SetTransform(new Vector2(value, YPos), ObjectBody.Rotation);
        }

        public ExportModel Export()
        {
            var retVal = new ExportModel();
            retVal.XPos = this.XPos;
            retVal.YPos = this.YPos;
            return retVal;
        }
    }

    public class BulletModel : GameObjectModel
    {
        
        public string BulletType { get; set; }
        
        public float Damage { get; set; }


        public BulletModel(Body b) : base(b)
        {
        }

        public new BulletExportModel Export()
        {
            var retVal = new BulletExportModel { XPos = this.XPos, YPos = this.YPos, BulletType = this.BulletType};
            return retVal;
        }
    }

    public class EnemyModel : GameObjectModel
    {
        public string EnemyType { get; set; }
        public float Damage { get; set; }

        public EnemyModel(Body b) : base(b)
        {
        }
    }

}