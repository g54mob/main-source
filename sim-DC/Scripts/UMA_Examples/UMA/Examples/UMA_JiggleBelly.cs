using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA.Examples
{
	public class UMA_JiggleBelly : MonoBehaviour
	{
		public float _bellyStiffness;

		public float _bellyMass;

		public float _bellyDamping;

		public float _bellyGravity;

		public bool _bellySquashAndStretch;

		public float _bellyFrontStretch;

		public float _bellySideStretch;

		private bool _initialized;

		private DynamicCharacterAvatar _avatar;

		private Dictionary<string, DnaSetter> _dna;

		private SkinnedMeshRenderer _renderer;

		private string _skeleton;

		private string _currentAvatar;

		private float _anatomyScaleFactor;

		private Vector3 _targetPos;

		private Vector3 _dynamicPos;

		private Transform _monitoredBone;

		private Vector3 _boneAxis;

		private float _targetDistance;

		private Vector3 _upDirection;

		private Vector3 _extraRotation;

		private Vector3 _force;

		private Vector3 _acceleration;

		private Vector3 _velocity;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Init()
		{
		}

		private void AvatarUpdated(UMAData data)
		{
		}

		private string GetSkeleton(string name)
		{
			return null;
		}

		private void InitializeBone()
		{
		}

		public void UpdateJiggleBone()
		{
		}

		private void LateUpdate()
		{
		}

		private void MonitorJiggling()
		{
		}

		public void OnCharacterComplete(UMAData umaData)
		{
		}
	}
}
