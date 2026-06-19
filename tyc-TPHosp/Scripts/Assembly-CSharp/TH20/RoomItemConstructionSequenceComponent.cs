using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class RoomItemConstructionSequenceComponent : MonoBehaviour
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private GameObject[] _builtObjects;

		[SerializeField]
		private GameObject[] _destroyedObjects;

		[SerializeField]
		private SharedInstance_TH20TH20_DemolishLandscapeItemEffect_Config _demolishEffectConfig;

		[SerializeField]
		private string _sfx = "LandPlotItemDestroy";

		[DontSave]
		private bool _refreshCalled;

		private static List<RoomItemConstructionSequenceComponent> _components = new List<RoomItemConstructionSequenceComponent>();

		private void Awake()
		{
			_components.Add(this);
		}

		private void OnDestroy()
		{
			_components.Remove(this);
		}

		public static RoomItemConstructionSequenceComponent Get(string name)
		{
			foreach (RoomItemConstructionSequenceComponent component in _components)
			{
				if (component._name == name)
				{
					return component;
				}
			}
			return null;
		}

		public bool HasEverBeenRefreshed()
		{
			return _refreshCalled;
		}

		public void Refresh(int progress, bool restoring)
		{
			_refreshCalled = true;
			if (_builtObjects != null)
			{
				for (int i = 0; i < _builtObjects.Length; i++)
				{
					GameObject gameObject = _builtObjects[i];
					if (!(gameObject != null))
					{
						continue;
					}
					if (i < progress)
					{
						if (!gameObject.activeSelf)
						{
							gameObject.SetActive(value: true);
							if (!restoring)
							{
								gameObject.AddComponent<PlotBuildingEffectComponent>().Initialise(gameObject.transform.position, 1f, popup: true);
							}
						}
					}
					else if (gameObject.activeSelf)
					{
						GameObjectUtils.SetActive(gameObject, isActive: false);
						AudioLoopPlayer component = gameObject.GetComponent<AudioLoopPlayer>();
						if ((bool)component)
						{
							component.UpdateAudioState();
						}
					}
				}
			}
			if (_destroyedObjects == null)
			{
				return;
			}
			for (int j = 0; j < _destroyedObjects.Length; j++)
			{
				GameObject gameObject2 = _destroyedObjects[j];
				if (gameObject2 != null)
				{
					if (j >= progress)
					{
						GameObjectUtils.SetActive(gameObject2, isActive: true);
					}
					else if (restoring)
					{
						GameObjectUtils.SetActive(gameObject2, isActive: false);
					}
					else if (gameObject2.GetComponent<DemolishLandscapeItemEffect>() == null)
					{
						gameObject2.AddComponent<DemolishLandscapeItemEffect>().Initialise(_demolishEffectConfig.Instance, 0f);
						AudioManager.Instance.Play(_sfx, gameObject2);
					}
				}
			}
		}
	}
}
