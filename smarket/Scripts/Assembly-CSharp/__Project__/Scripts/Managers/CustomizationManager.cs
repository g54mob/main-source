using System;
using System.Collections.Generic;
using TinyGiantStudio.Text;
using UnityEngine;
using __Project__.Scripts.Cameras;
using __Project__.Scripts.Data;

namespace __Project__.Scripts.Managers
{
	public class CustomizationManager : NoktaSingleton<CustomizationManager>
	{
		private CustomizationData m_CustomizationData;

		[SerializeField]
		private DoorSwitchCamera m_SwitchCamera;

		[SerializeField]
		private Modular3DText m_ShopNameText;

		[SerializeField]
		private MeshRenderer m_NameBackgroundRenderer;

		[SerializeField]
		private List<EntranceVariantSignboard> m_SignboardRenderers;

		[Header("Sounds")]
		[SerializeField]
		private AudioSource m_DoorSelectedSound;

		[SerializeField]
		private AudioSource m_NameChangedSound;

		[SerializeField]
		private AudioSource m_DoorSwitchedSound;

		public Action onNameChanged;

		public Action onDoorPositionChanged;

		public Action onFrontStyleChanged;

		public CustomizationData CustomizationData => null;

		public void OnPlayerConnected(PlayerInstance player)
		{
		}

		public void OnLocalPlayerUpdated(PlayerInstance player)
		{
		}

		private void Start()
		{
		}

		public void Initialize()
		{
		}

		public void ChangeShopName(string shopName, bool isFinalChoice)
		{
		}

		public void ChangeShopColor(Color color)
		{
		}

		public void ChangeShopColor(Color color, bool isFinalized)
		{
		}

		public void ChangeNameBackgroundColor(Color color)
		{
		}

		public void ChangeNameBackgroundColor(Color color, bool isFinalized)
		{
		}

		public void SetDefaultNameBackground(bool isSave)
		{
		}

		public void ChangeShopNameSize(float size, bool isHorizontal)
		{
		}

		public void ChangeShopNameSize(float size, bool isHorizontal, bool isFinal)
		{
		}

		public void SelectDoorPosition(int index)
		{
		}

		public void PlayDoorSwitchSound()
		{
		}

		public void PlayShopNameSound()
		{
		}
	}
}
