using System;
using System.Collections.Generic;
using InputControl;
using UnityEngine;

namespace UI
{
	public class RouteOrdeal : MonoBehaviour
	{
		[Serializable]
		private class OrdialObject
		{
			public eLastBattleKey key;

			public GameObject ordial;

			public CursorUIItem padButtonItem;

			public GameObject selectCursor;

			private MstOrdealDataEntities _mstData;

			public MstOrdealDataEntities MstData
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[SerializeField]
		private GameObject routeBackground;

		[SerializeField]
		private GameObject referenceBackground;

		[SerializeField]
		private List<OrdialObject> ordialObjects;

		[SerializeField]
		private ChoiceMenuButtonBase ordealDetail;

		private OrdialObject _nowFocus;

		private int _selectIdx;

		private bool _isReference;

		private bool _isEnable;

		public void Init(bool enableOrdial, bool isReference, eLastBattleKey hasKey)
		{
		}

		public void UpdateUI(eLastBattleKey hasKey, bool isEndless = false)
		{
		}

		private OrdialObject GetOrdealObject(eLastBattleKey key)
		{
			return null;
		}

		private void OnSelect(OrdialObject item)
		{
		}

		public void OnDeSelect()
		{
		}

		public void OnNextOrdeal()
		{
		}
	}
}
