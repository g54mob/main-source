using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dorfromantik.UI.MainMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class SaveFileSelectionScreen : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<SaveGameUi, DateTime> _003C_003E9__15_0;

			internal DateTime _003CUpdateSaveGameOrder_003Eb__15_0(SaveGameUi x)
			{
				return x.LastPlayedTime;
			}
		}

		private sealed class _003CUpdateNavigationNextFrame_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SaveFileSelectionScreen _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CUpdateNavigationNextFrame_003Ed__16(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				SaveFileSelectionScreen saveFileSelectionScreen = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (saveFileSelectionScreen.pendingNavigationUpdate)
					{
						return false;
					}
					saveFileSelectionScreen.pendingNavigationUpdate = true;
					_003C_003E2__current = new WaitForEndOfFrame();
					_003C_003E1__state = 1;
					return true;
				case 1:
				{
					_003C_003E1__state = -1;
					Vector2 sizeDelta = saveFileSelectionScreen.saveGameGridLayout.GetComponent<RectTransform>().sizeDelta;
					Vector2 vector = saveFileSelectionScreen.saveGameGridLayout.cellSize + saveFileSelectionScreen.saveGameGridLayout.spacing;
					int num2 = Mathf.FloorToInt((sizeDelta.x - (float)saveFileSelectionScreen.saveGameGridLayout.padding.horizontal) / vector.x);
					saveFileSelectionScreen.allSelectables.Clear();
					foreach (SaveGameUi visibleSaveGameUi in saveFileSelectionScreen.visibleSaveGameUis)
					{
						saveFileSelectionScreen.allSelectables.Add(visibleSaveGameUi.uiSelectable);
					}
					for (int i = 0; i < saveFileSelectionScreen.allSelectables.Count; i++)
					{
						Navigation navigation = saveFileSelectionScreen.allSelectables[i].navigation;
						navigation.mode = Navigation.Mode.Explicit;
						navigation.selectOnLeft = ((i % num2 == 0) ? null : saveFileSelectionScreen.allSelectables[i - 1]);
						navigation.selectOnRight = ((i % num2 != num2 - 1 && saveFileSelectionScreen.allSelectables.Count > i + 1) ? saveFileSelectionScreen.allSelectables[i + 1] : null);
						navigation.selectOnUp = ((i - num2 >= 0) ? saveFileSelectionScreen.allSelectables[i - num2] : null);
						navigation.selectOnDown = ((saveFileSelectionScreen.allSelectables.Count > i + num2) ? saveFileSelectionScreen.allSelectables[i + num2] : null);
						saveFileSelectionScreen.allSelectables[i].navigation = navigation;
					}
					saveFileSelectionScreen.pendingNavigationUpdate = false;
					saveFileSelectionScreen.saveGameContainer.parent.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
					return false;
				}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		[SerializeField]
		private RectTransform saveGameContainer;

		[SerializeField]
		private SaveFileManager saveFileManager;

		[SerializeField]
		private SaveGameUi saveGameUiPrefab;

		[SerializeField]
		private SaveGameLoadingInitiator saveGameLoadingInitiator;

		private List<SaveGameUi> visibleSaveGameUis = new List<SaveGameUi>();

		private List<Selectable> allSelectables = new List<Selectable>();

		private GridLayoutGroup saveGameGridLayout;

		private ScrollRect scrollView;

		private bool pendingNavigationUpdate;

		private GameMode GameMode => saveGameLoadingInitiator.SelectedGameMode;

		private void Awake()
		{
			saveGameGridLayout = saveGameContainer.GetComponent<GridLayoutGroup>();
			scrollView = GetComponentInChildren<ScrollRect>();
		}

		private void OnEnable()
		{
			UpdateSaveFileUi();
			visibleSaveGameUis[0].uiSelectable.Select();
		}

		private void UpdateSaveFileUi()
		{
			foreach (SaveGameUi visibleSaveGameUi in visibleSaveGameUis)
			{
				UnityEngine.Object.Destroy(visibleSaveGameUi.gameObject);
			}
			visibleSaveGameUis = new List<SaveGameUi>();
			foreach (KeyValuePair<string, SaveGameData_003> item in saveFileManager.loadedSaveGames[GameMode])
			{
				if (item.Value != saveGameLoadingInitiator.SelectedSaveGame)
				{
					CreateSaveGameUi(item.Value, setupScreenshot: true);
				}
			}
			UpdateSaveGameOrder();
			LayoutRebuilder.MarkLayoutForRebuild(saveGameContainer);
			Canvas.ForceUpdateCanvases();
			StartCoroutine(UpdateNavigationNextFrame());
		}

		private void CreateSaveGameUi(SaveGameData_003 saveGameData, bool setupScreenshot)
		{
			SaveGameUi saveGameUi = UnityEngine.Object.Instantiate(saveGameUiPrefab, saveGameContainer);
			saveGameUi.Setup(null, saveGameData, isAutosaveContainer: false, setupScreenshot);
			saveGameUi.SetMode(SaveFileUiMode.OverwriteGame);
			saveGameUi.transform.SetAsLastSibling();
			visibleSaveGameUis.Add(saveGameUi);
		}

		private void UpdateSaveGameOrder()
		{
			int num = GetComponentsInChildren<SaveGameUi>().Length - visibleSaveGameUis.Count;
			visibleSaveGameUis = Enumerable.ToList(Enumerable.OrderByDescending(visibleSaveGameUis, (SaveGameUi x) => x.LastPlayedTime));
			for (int num2 = 0; num2 < visibleSaveGameUis.Count; num2++)
			{
				visibleSaveGameUis[num2].transform.SetSiblingIndex(num2 + num + 2);
			}
		}

		private IEnumerator UpdateNavigationNextFrame()
		{
			return new _003CUpdateNavigationNextFrame_003Ed__16(0)
			{
				_003C_003E4__this = this
			};
		}
	}
}
