using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.DroneSkins
{
	public class DroneSkin : UniqueScriptableObject
	{
		public EDroneSkinSet Set;

		public Texture2D Icon;

		public int Width;

		public int Height;

		public Sprite SkinTexture;
	}
}
