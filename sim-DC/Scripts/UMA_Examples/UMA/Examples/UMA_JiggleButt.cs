using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA.Examples
{
	public class UMA_JiggleButt : MonoBehaviour
	{
		public float _buttStiffness;

		public float _buttMass;

		public float _buttDamping;

		public float _buttGravity;

		public bool _buttSquashAndStretch;

		public float _buttFrontStretch;

		public float _buttSideStretch;

		private bool _initialized;

		private DynamicCharacterAvatar _avatar;

		private Dictionary<string, DnaSetter> _dna;

		private SkinnedMeshRenderer _renderer;

		private string _skeleton;

		private string _gender;

		private string _currentAvatar;

		public List<JiggleElement> _jigglers;

		private JiggleElement _jiggler;

		private float _anatomyScaleFactor;

		private Vector3 _targetPos;

		private Vector3 _dynamicPos;

		private Transform _monitoredBone;

		private Vector3 _boneAxis;

		private float _targetDistance;

		private Vector3 _upDirection;

		private Vector3 _extraRotation;

		private float _stiffness;

		private float _mass;

		private float _damping;

		private float _gravity;

		private Vector3 _force;

		private Vector3 _acceleration;

		private Vector3 _velocity;

		private float _sideStretch;

		private float _frontStretch;

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

		private void InitializeBone(JiggleElement jiggler)
		{
		}

		public void UpdateJiggleBone(JiggleElement jiggler)
		{
		}

		private void LateUpdate()
		{
		}

		private void MonitorJiggling(JiggleElement jiggler)
		{
		}

		public void OnCharacterComplete(UMAData umaData)
		{
		}
	}
}
