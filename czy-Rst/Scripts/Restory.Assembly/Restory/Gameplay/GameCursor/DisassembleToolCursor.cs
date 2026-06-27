using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameCursor
{
	public class DisassembleToolCursor : MonoBehaviour, IInitializable, ISpecialCursor
	{
		[SerializeField]
		private RectTransform rectTransform;

		private VirtualCursorView virtualCursor;

		[Inject]
		private void Construct(VirtualCursorView virtualCursor)
		{
			this.virtualCursor = virtualCursor;
		}

		public void Initialize()
		{
			base.transform.SetParent(virtualCursor.transform);
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
			Hide();
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void SetSize(Vector2 size)
		{
			rectTransform.sizeDelta = size;
		}
	}
}
