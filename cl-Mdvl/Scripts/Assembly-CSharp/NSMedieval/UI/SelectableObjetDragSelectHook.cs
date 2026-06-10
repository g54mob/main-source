using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SelectableObjetDragSelectHook : MonoBehaviour, IObserver
	{
		[SerializeField]
		private RectTransform selectionBox;

		private void Start()
		{
			selectionBox.gameObject.SetActive(value: false);
			MonoSingleton<SelectableObjectDragSelectManager>.Instance.Hook2DDragBox(selectionBox);
		}
	}
}
