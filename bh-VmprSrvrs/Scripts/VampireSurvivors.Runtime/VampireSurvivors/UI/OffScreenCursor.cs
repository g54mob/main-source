using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Cursors;

namespace VampireSurvivors.UI
{
	public class OffScreenCursor : MonoBehaviour
	{
		[SerializeField]
		private Image _CursorRenderer;

		[SerializeField]
		private UISpriteAnimation _ImageSpriteAnimation;

		[SerializeField]
		private Image _IconRenderer;

		[SerializeField]
		private GameObject _Target;

		public CursorData Data { get; private set; }

		private void Update()
		{
		}

		public void Init(CursorData cursorData, GameObject target)
		{
		}

		private void InitAnimation(CursorData cursorData)
		{
		}
	}
}
