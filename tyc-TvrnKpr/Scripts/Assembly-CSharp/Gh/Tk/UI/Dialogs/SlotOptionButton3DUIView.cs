using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class SlotOptionButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private Transform _iconSocket;

		private GameObject _icon;

		[SerializeField]
		private TextMeshProI18n _textMesh;

		[SerializeField]
		private SpriteRenderer _backgroundRenderer;

		[SerializeField]
		private BoxColliderResizer _resizer;

		[SerializeField]
		private GameObject _ownedOptionsParent;

		[SerializeField]
		private Container3DUIView _ownedOptionsContainer;

		[SerializeField]
		private GameObject _ownedOptionPrefab;

		public SlotOption Option { get; private set; }

		public void SetData(ScheduleDialog3DUIView dialog, SlotOption option)
		{
		}
	}
}
