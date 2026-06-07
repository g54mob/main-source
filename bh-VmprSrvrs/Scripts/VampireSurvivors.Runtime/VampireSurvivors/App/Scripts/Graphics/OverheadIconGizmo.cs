using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.App.Scripts.Graphics
{
	public class OverheadIconGizmo : PoolableMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _Icon;

		[SerializeField]
		private GenericShadowText _TextValue;

		public SpriteRenderer Icon => null;

		public GenericShadowText TextValue => null;

		public void Play(string frameName, string value, Color? color, VampireSurvivors.Objects.Characters.CharacterController character, float displayTimeMultiplier = 1f, Vector2 vOffset = default(Vector2), string textureName = "items")
		{
		}
	}
}
