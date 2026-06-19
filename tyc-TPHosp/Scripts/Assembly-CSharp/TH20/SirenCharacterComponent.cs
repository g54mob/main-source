using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SirenCharacterComponent : EntityTickComponent
	{
		private SirenCharacterComponentConfig _config;

		[DontSave]
		private GameObject _sirenInstance;

		public void Setup(SirenCharacterComponentConfig config)
		{
			_config = config;
			CreateSirenInstance();
		}

		private void CreateSirenInstance()
		{
			_sirenInstance = UnityEngine.Object.Instantiate(_config.SirenPrefab, Vector3.zero, Quaternion.identity, GetOwner<Character>().GameObject.transform);
			_sirenInstance.GetComponent<SirenAnimatorComponent>().AssignPatient(GetOwner<Patient>());
		}

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			GetOwner<Character>().PostFixName = "(VIP)";
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			CreateSirenInstance();
		}

		public override void Destroy()
		{
			GetOwner<Character>().PostFixName = "";
			if (_sirenInstance != null)
			{
				UnityEngine.Object.Destroy(_sirenInstance);
			}
			base.Destroy();
		}

		public void SetVisible(bool visible)
		{
			GameObjectUtils.SetActive(_sirenInstance, visible);
		}

		public override void LateTick()
		{
			base.LateTick();
			if (_sirenInstance != null)
			{
				Patient owner = GetOwner<Patient>();
				ObjectInteraction interaction = owner.Interaction;
				_sirenInstance.transform.position = owner.Visual.HeadSocket.position + new Vector3(0f, owner.Illness.SirenHeightOffset, 0f);
				bool flag = (interaction == null || interaction.ParentRoomItem == null || interaction.ParentRoomItem.Definition.ItemType != RoomItemDefinition.Type.Machine) && !base.Level.StatusIconManager.HasActiveStatusIcon(owner) && !owner.IsDying();
				if (_sirenInstance.activeSelf != flag)
				{
					_sirenInstance.SetActive(flag);
				}
			}
		}
	}
}
