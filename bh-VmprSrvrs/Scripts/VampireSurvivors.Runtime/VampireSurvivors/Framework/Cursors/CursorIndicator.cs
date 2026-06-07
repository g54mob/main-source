using QFSW.MOP2;
using TMPro;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Cursors
{
	public class CursorIndicator : PoolableMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _CursorRenderer;

		[SerializeField]
		private SpriteRenderer _IconRenderer;

		[SerializeField]
		private SpriteAnimation _CursorAnimation;

		[SerializeField]
		private TextMeshPro _Text;

		public CursorData Data { get; private set; }

		public GameObject Target { get; private set; }

		public SpriteRenderer CursorRenderer => null;

		public void Init(CursorData cursorData, GameObject target)
		{
		}

		public void Despawn()
		{
		}

		private void InitAnimation(CursorData cursorData)
		{
		}

		public void SetVisible(bool visible)
		{
		}
	}
}
