using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Keybinds
{
	public class FillupKeybinds : SerializedMonoBehaviour
	{
		public UIGrid Grid;

		public UIScrollView View;

		public KeybindPrefab Prefab;

		public void Start()
		{
			Init();
		}

		public void Init()
		{
			foreach (KeybindSetting workshopKeybind in BaseSingleton<KeybindManager>.Instance.GetWorkshopKeybinds())
			{
				KeybindPrefab keybindPrefab = Object.Instantiate(Prefab);
				keybindPrefab.Init(workshopKeybind, View);
				keybindPrefab.transform.position = Grid.transform.position;
				keybindPrefab.transform.parent = Grid.transform;
				keybindPrefab.transform.localScale = Prefab.transform.localScale;
			}
			Grid.Reposition();
		}
	}
}
