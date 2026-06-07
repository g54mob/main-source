using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UI.Modal;
using UnityEngine;

namespace UI
{
	public class UIModalManager : MonoBehaviour
	{
		public List<UIModalInfo> modalInfo;

		public Transform modalArea;

		[HideInInspector]
		public List<UIModal> openModals;

		public void Init()
		{
		}

		public UIModal OpenModal<T>(ModalType modalType, T initPar, List<UIButton> modalOpenButton = null)
		{
			return null;
		}

		public void CloseLastModal()
		{
		}

		public void ActivatePanelOnlySelectedModal(int index)
		{
		}

		public void CloseModal(int index)
		{
		}

		public void CloseModal(UIModal modal)
		{
		}

		public void CloseAllModals()
		{
		}

		public GameObject GetModal(ModalType modalToGet)
		{
			return null;
		}
	}
}
