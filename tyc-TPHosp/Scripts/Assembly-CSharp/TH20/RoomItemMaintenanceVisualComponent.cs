using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemMaintenanceVisualComponent : MonoBehaviour
	{
		[SerializeField]
		private LODGroup _lodGroup;

		[SerializeField]
		private Renderer[] _lodBroken;

		[SerializeField]
		private Renderer[] _lodRepaired;

		private Animator _animator;

		private RuntimeAnimatorController _runtimeAnimatorController;

		private bool _hasMaintenanceParam;

		private bool _initialised;

		private const string MaintenanceAnimParameter = "Maintenance";

		public void Initialise(AttributeFloat maintenanceLevel)
		{
			if (!_initialised)
			{
				_initialised = true;
				_animator = base.gameObject.GetComponentInChildren<Animator>();
				if ((bool)_animator)
				{
					_animator.keepAnimatorControllerStateOnDisable = true;
				}
				maintenanceLevel.Changed(MaintenanceLevelChanged);
				maintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemMaintenanceThreshold, SetLODBroken, checkCallback: true);
				maintenanceLevel.LessThan(GameAlgorithms.Config.ItemMaintenanceThreshold, SetLODRepaired, checkCallback: true);
				MaintenanceLevelChanged(maintenanceLevel.Value());
			}
		}

		private bool HasMaintenanceParam()
		{
			if (_animator != null && _animator.runtimeAnimatorController != _runtimeAnimatorController)
			{
				_runtimeAnimatorController = _animator.runtimeAnimatorController;
				_hasMaintenanceParam = _animator.HasParameter("Maintenance");
			}
			return _hasMaintenanceParam;
		}

		public void MaintenanceLevelChanged(float newValue)
		{
			if (_animator != null && _animator.runtimeAnimatorController != null && base.gameObject.activeSelf && HasMaintenanceParam())
			{
				_animator.SetFloat("Maintenance", newValue / 100f);
			}
		}

		private void SetLODRepaired()
		{
			SetLODGroup(_lodRepaired, _lodBroken);
		}

		private void SetLODBroken()
		{
			SetLODGroup(_lodBroken, _lodRepaired);
		}

		private void SetLODGroup(Renderer[] activeRenderers, Renderer[] disabledRenderers)
		{
			if (!(_lodGroup != null))
			{
				return;
			}
			if (activeRenderers != null && activeRenderers.Length != 0)
			{
				LOD[] lODs = _lodGroup.GetLODs();
				lODs[2].renderers = activeRenderers;
				_lodGroup.SetLODs(lODs);
				_lodGroup.RecalculateBounds();
				Renderer[] array = activeRenderers;
				for (int i = 0; i < array.Length; i++)
				{
					GameObjectUtils.SetActive(array[i].gameObject, isActive: true);
				}
			}
			if (disabledRenderers != null && disabledRenderers.Length != 0)
			{
				Renderer[] array = disabledRenderers;
				for (int i = 0; i < array.Length; i++)
				{
					GameObjectUtils.SetActive(array[i].gameObject, isActive: false);
				}
			}
		}
	}
}
