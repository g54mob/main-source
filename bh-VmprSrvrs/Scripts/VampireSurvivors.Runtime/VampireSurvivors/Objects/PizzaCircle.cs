using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;

namespace VampireSurvivors.Objects
{
	public class PizzaCircle : GameMonoBehaviour
	{
		public EnemyType EnemyTag;

		private SpriteRenderer _pizzaSprite;

		private SpriteRenderer _warningSprite;

		private Circle _circle;

		private MapToken _mapToken;

		public Circle Circle => null;

		private void Awake()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void SetSprite(string texture, string frameName)
		{
		}

		public void SetMapToken(string texture, string frameName)
		{
		}

		public void CleanUp()
		{
		}

		public void Init(float radius)
		{
		}

		public bool CheckPizzaOverlap(Vector2 point)
		{
			return false;
		}

		public void ShowWarning()
		{
		}

		public void ShowFinalWarning()
		{
		}

		public void SetAlpha(float alpha)
		{
		}

		public void SetMapTokenHidden(bool isHidden)
		{
		}
	}
}
