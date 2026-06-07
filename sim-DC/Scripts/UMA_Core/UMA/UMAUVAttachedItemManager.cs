using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class UMAUVAttachedItemManager : MonoBehaviour
	{
		public DynamicCharacterAvatar avatar;

		public List<UMAUVAttachedItem> pendingAttachedItemsList;

		private UMAData umaData;

		public Dictionary<string, UMAUVAttachedItem> attachedItemLookup;

		public Dictionary<string, UMAUVAttachedItem> attachedItems => null;

		public event Action<UMAData> UmaUvAttachedItemManagerUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void Setup(UMAData umaData)
		{
		}

		public void UMABegun(UMAData umaData)
		{
		}

		public void UMAUpdated(UMAData umaData)
		{
		}

		public void OldUMAUpdated(UMAData umaData)
		{
		}

		public void LateUpdate()
		{
		}

		public void AddAttachedItem(UMAData umaData, UMAUVAttachedItemLauncher uMAUVAttachedItemLauncher, bool Activate)
		{
		}
	}
}
