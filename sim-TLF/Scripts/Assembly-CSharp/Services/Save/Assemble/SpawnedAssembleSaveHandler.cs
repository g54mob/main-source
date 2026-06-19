using System;
using AssembleSystem;
using UnityEngine;
using Zenject;

namespace Services.Save.Assemble
{
	public class SpawnedAssembleSaveHandler : MonoBehaviour
	{
		private AssembleObjectParent _assembleParent;

		[Inject]
		private AssembleSaveRegistry _registry;

		public string SaveKey { get; private set; }

		public int Priority => 10;

		public void Init(AssembleObjectParent assembleParent, string overrideId = null)
		{
			_assembleParent = assembleParent;
			SaveKey = overrideId ?? Guid.NewGuid().ToString();
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		public void OnSave()
		{
			_registry.Save(SaveKey, AssembleSaveHelper.BuildSaveData(_assembleParent));
		}

		public void OnLoad()
		{
			if (_registry.TryGet(SaveKey, out var data))
			{
				AssembleSaveHelper.ApplySaveData(_assembleParent, data);
			}
		}
	}
}
