using System;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Phaser
{
	public class PhaserWorld : GameMonoBehaviour
	{
		[SerializeField]
		private bool _EnableHideFlags;

		private Transform _phaserSpritesParent;

		private static PhaserWorld _instance;

		public static PhaserWorld Instance => null;

		private void Awake()
		{
		}

		public T AddPhaserSpriteOfType<T>(float2 pos, string texture = null, string spriteName = null) where T : PhaserSprite
		{
			return null;
		}

		public PhaserSprite AddPhaserSprite(Vector2 pos, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public PhaserSprite AddPhaserSprite(Vector2 pos, string texture = null, string spriteName = null)
		{
			return null;
		}

		public PhaserSprite AddRectangle(Vector2 pos, float width, float height, uint fillColor)
		{
			return null;
		}

		private void GenerateParents()
		{
		}

		private void ToggleHideFlags()
		{
		}
	}
}
