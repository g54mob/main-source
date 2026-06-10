using Controller;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	public class TutorialPanelController : PanelBase
	{
		[SerializeField]
		private GameObject[] panels;

		[SerializeField]
		private GameObject[] buttons;

		[SerializeField]
		private GameObject back;

		[SerializeField]
		private GameObject next;

		[SerializeField]
		private GameObject selector;

		public void HidePanel()
		{
			Hide();
		}

		public override void Hide()
		{
			if (base.gameObject.activeSelf)
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
				MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
				base.Hide();
			}
		}

		public void NextTab()
		{
			int num = 0;
			for (int i = 0; i < panels.Length; i++)
			{
				if (panels[i].activeSelf)
				{
					num = i;
				}
			}
			if (num < panels.Length - 1)
			{
				panels[num].SetActive(value: false);
				num++;
				panels[num].SetActive(value: true);
				MoveSelector(buttons[num]);
			}
			ShowHideBackNext(num);
		}

		public void BackTab()
		{
			int num = 0;
			for (int i = 0; i < panels.Length; i++)
			{
				if (panels[i].activeSelf)
				{
					num = i;
				}
			}
			if (num > 0)
			{
				panels[num].SetActive(value: false);
				num--;
				panels[num].SetActive(value: true);
				MoveSelector(buttons[num]);
			}
			ShowHideBackNext(num);
		}

		public void ChangeTab(GameObject pnl)
		{
			int activePanelIndex = 0;
			GameObject[] array = panels;
			foreach (GameObject gameObject in array)
			{
				if (gameObject.GetInstanceID() == pnl.GetInstanceID())
				{
					gameObject.SetActive(value: true);
					for (int j = 0; j < panels.Length; j++)
					{
						if (pnl == panels[j])
						{
							activePanelIndex = j;
						}
					}
				}
				else
				{
					gameObject.SetActive(value: false);
				}
			}
			ShowHideBackNext(activePanelIndex);
		}

		public void MoveSelector(GameObject btn)
		{
			selector.transform.position = btn.transform.position;
		}

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.LowerRight;
		}

		protected override void UpdatePanel()
		{
		}

		protected override void OnEnable()
		{
			MonoSingleton<UIController>.Instance.Attach(this);
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
		}

		private void ShowHideBackNext(int activePanelIndex)
		{
			if (activePanelIndex <= 0)
			{
				back.SetActive(value: false);
			}
			else
			{
				back.SetActive(value: true);
			}
			if (activePanelIndex >= panels.Length - 1)
			{
				next.SetActive(value: false);
			}
			else
			{
				next.SetActive(value: true);
			}
		}
	}
}
