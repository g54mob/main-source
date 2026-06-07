using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class BaseBuilder : MonoBehaviour
	{
		private int _clutterRngSeed;

		protected Buildable _lastBuildable;

		[SerializeField]
		protected RuntimeAnimatorController _onBuildAnimator;

		public Buildable SelectedBuildable { get; protected set; }

		protected Vector3 SelectedBuildableInitialPosition { get; set; }

		protected Quaternion SelectedBuildableInitialRotation { get; set; }

		public bool IsEditMode { get; protected set; }

		public string SelectedBuildItemId { get; set; }

		public virtual bool IsBuilding { get; protected set; }

		public virtual void Refresh()
		{
		}

		protected void DisableSelectedBuildable()
		{
		}

		public abstract bool Esc();

		public virtual void ExitBuildMode(bool switchInputMode = true)
		{
		}

		public virtual void EnterBuildMode(Vector3 coords)
		{
		}

		public virtual void EnterEditMode(Buildable selectedBuildable)
		{
		}

		public virtual void ExitEditMode(bool resetPosition = false)
		{
		}

		internal void StopBuilding()
		{
		}

		protected static void AnimateWalls(Dictionary<int, List<Wall>> walls)
		{
		}

		public static void SetDecorEntityObjectOnInstance(GameObject instance, GameObject prefab)
		{
		}

		protected bool IsSelectedBuildableHoveringOver(Buildable buildable)
		{
			return false;
		}

		protected void ApplyBuildAnimation(Buildable buildable, RuntimeAnimatorController animationController)
		{
		}
	}
}
