using AssembleSystem;
using MyBox;
using UnityEngine;
using Zenject;

namespace Services.Save.Assemble
{
	public class SceneAssembleSaveHandler : MonoBehaviour
	{
		[SerializeField]
		[ReadOnly(new string[] { })]
		private string _id;

		[SerializeField]
		private AssembleObjectParent _assembleParent;

		[SerializeField]
		private float _upOffset;

		[SerializeField]
		private Rigidbody _rootRb;

		[Inject]
		private AssembleSaveRegistry _registry;

		public string SaveKey => _id;

		public int Priority => 10;

		private void Awake()
		{
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
			if (_rootRb != null)
			{
				_rootRb.isKinematic = true;
			}
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		public void OnSave()
		{
			_registry.Save(_id, AssembleSaveHelper.BuildSaveData(_assembleParent));
		}

		public void OnLoad()
		{
			if (_registry.TryGet(_id, out var data))
			{
				AssembleSaveHelper.ApplySaveData(_assembleParent, data);
			}
			if (_rootRb != null)
			{
				_rootRb.isKinematic = false;
			}
		}
	}
}
