using UnityEngine;

namespace TH20
{
	public class HubMenuTabs : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		private RectTransform[] _tabTransforms;

		private HubMenuTab[] _tabs;

		private Vector2[] _tabInitialPos;

		private Vector2[] _tabTargetPos;

		private HubMenuTab _openTab;

		protected void Start()
		{
			_tabTransforms = new RectTransform[base.transform.childCount];
			_tabs = new HubMenuTab[base.transform.childCount];
			_tabInitialPos = new Vector2[base.transform.childCount];
			_tabTargetPos = new Vector2[base.transform.childCount];
			for (int i = 0; i < base.transform.childCount; i++)
			{
				_tabTransforms[i] = base.transform.GetChild(i) as RectTransform;
				if (_tabTransforms[i] != null)
				{
					_tabInitialPos[i] = _tabTransforms[i].anchoredPosition;
					_tabTargetPos[i] = _tabTransforms[i].anchoredPosition;
				}
				_tabs[i] = base.transform.GetChild(i).GetComponent<HubMenuTab>();
				if (_tabs[i] != null)
				{
					_tabs[i].AssignHubMenuTabs(this);
				}
			}
		}

		private int FindTab(HubMenuTab tab)
		{
			for (int i = 0; i < _tabs.Length; i++)
			{
				if (tab == _tabs[i])
				{
					return i;
				}
			}
			return -1;
		}

		public void ToggleTab(HubMenuTab tab)
		{
			int num = FindTab(tab);
			if (num >= 0)
			{
				if (_openTab == tab)
				{
					CloseAllTabs();
				}
				else
				{
					OpenTab(num);
				}
			}
		}

		private void OpenTab(int tabIndex)
		{
			if (_openTab != null)
			{
				IOnHubTabClose[] componentsInChildren = _openTab.gameObject.GetComponentsInChildren<IOnHubTabClose>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].OnHubTabClose();
				}
			}
			_openTab = _tabs[tabIndex];
			IOnHubTabOpen[] componentsInChildren2 = _openTab.gameObject.GetComponentsInChildren<IOnHubTabOpen>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].OnHubTabOpen();
			}
			float num = 0f;
			for (int num2 = _tabs.Length - 1; num2 >= 0; num2--)
			{
				HubMenuTab hubMenuTab = _tabs[num2];
				RectTransform rectTransform = _tabTransforms[num2];
				if (num2 == tabIndex)
				{
					num += Mathf.Max(0f, rectTransform.rect.width - hubMenuTab.TabWidthOffset);
				}
				_tabTargetPos[num2] = _tabInitialPos[num2] + new Vector2(num, 0f);
			}
		}

		private void CloseAllTabs()
		{
			if (_openTab != null)
			{
				IOnHubTabClose[] componentsInChildren = _openTab.gameObject.GetComponentsInChildren<IOnHubTabClose>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].OnHubTabClose();
				}
			}
			_openTab = null;
			float x = 0f;
			for (int num = _tabs.Length - 1; num >= 0; num--)
			{
				_tabTargetPos[num] = _tabInitialPos[num] + new Vector2(x, 0f);
			}
		}

		protected void Update()
		{
			for (int num = _tabs.Length - 1; num >= 0; num--)
			{
				RectTransform obj = _tabTransforms[num];
				Vector2 vector = _tabTargetPos[num];
				Vector2 anchoredPosition = obj.anchoredPosition;
				Vector2 vector2 = vector - anchoredPosition;
				if (vector2.x > 0f)
				{
					anchoredPosition.x = Mathf.Min(anchoredPosition.x + _speed * Time.unscaledDeltaTime, vector.x);
				}
				else if (vector2.x < 0f)
				{
					anchoredPosition.x = Mathf.Max(anchoredPosition.x - _speed * Time.unscaledDeltaTime, vector.x);
				}
				obj.anchoredPosition = anchoredPosition;
			}
		}
	}
}
