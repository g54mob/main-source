using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Object Controller")]
	public class ObjectController : SplineUser
	{
		[Serializable]
		internal class ObjectControl
		{
			public GameObject gameObject;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3 scale;

			public bool active;

			public Vector3 baseScale;

			public bool isNull => false;

			public Transform transform => null;

			public ObjectControl(GameObject input)
			{
			}

			public void Destroy()
			{
			}

			public void DestroyImmediate()
			{
			}

			public void Apply()
			{
			}
		}

		public enum ObjectMethod
		{
			Instantiate = 0,
			GetChildren = 1
		}

		public enum Positioning
		{
			Stretch = 0,
			Clip = 1
		}

		public enum Iteration
		{
			Ordered = 0,
			Random = 1
		}

		[CompilerGenerated]
		private sealed class _003CInstantiateAllWithDelay_003Ed__116 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ObjectController _003C_003E4__this;

			private int _003Ci_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CInstantiateAllWithDelay_003Ed__116(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[HideInInspector]
		public GameObject[] objects;

		[SerializeField]
		[HideInInspector]
		private float _evaluateOffset;

		[SerializeField]
		[HideInInspector]
		private int _spawnCount;

		[SerializeField]
		[HideInInspector]
		private Positioning _objectPositioning;

		[SerializeField]
		[HideInInspector]
		private Iteration _iteration;

		[SerializeField]
		[HideInInspector]
		private int _randomSeed;

		[SerializeField]
		[HideInInspector]
		private Vector3 _minOffset;

		[SerializeField]
		[HideInInspector]
		private Vector3 _maxOffset;

		[SerializeField]
		[HideInInspector]
		private bool _offsetUseWorldCoords;

		[SerializeField]
		[HideInInspector]
		private Vector3 _minRotation;

		[SerializeField]
		[HideInInspector]
		private Vector3 _maxRotation;

		[SerializeField]
		[HideInInspector]
		private bool _uniformScaleLerp;

		[SerializeField]
		[HideInInspector]
		private Vector3 _minScaleMultiplier;

		[SerializeField]
		[HideInInspector]
		private Vector3 _maxScaleMultiplier;

		[SerializeField]
		[HideInInspector]
		private bool _shellOffset;

		[SerializeField]
		[HideInInspector]
		private bool _applyRotation;

		[SerializeField]
		[HideInInspector]
		private bool _rotateByOffset;

		[SerializeField]
		[HideInInspector]
		private bool _applyScale;

		[SerializeField]
		[HideInInspector]
		private ObjectMethod _objectMethod;

		[HideInInspector]
		public bool delayedSpawn;

		[HideInInspector]
		public float spawnDelay;

		[SerializeField]
		[HideInInspector]
		private int lastChildCount;

		[SerializeField]
		[HideInInspector]
		private ObjectControl[] spawned;

		[SerializeField]
		[HideInInspector]
		private bool _useCustomObjectDistance;

		[SerializeField]
		[HideInInspector]
		private float _minObjectDistance;

		[SerializeField]
		[HideInInspector]
		private float _maxObjectDistance;

		[SerializeField]
		[HideInInspector]
		private ObjectControllerCustomRuleBase _customOffsetRule;

		[SerializeField]
		[HideInInspector]
		private ObjectControllerCustomRuleBase _customRotationRule;

		[SerializeField]
		[HideInInspector]
		private ObjectControllerCustomRuleBase _customScaleRule;

		private System.Random offsetRandomizer;

		private System.Random shellRandomizer;

		private System.Random rotationRandomizer;

		private System.Random scaleRandomizer;

		private System.Random distanceRandomizer;

		public ObjectMethod objectMethod
		{
			get
			{
				return default(ObjectMethod);
			}
			set
			{
			}
		}

		public int spawnCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Positioning objectPositioning
		{
			get
			{
				return default(Positioning);
			}
			set
			{
			}
		}

		public Iteration iteration
		{
			get
			{
				return default(Iteration);
			}
			set
			{
			}
		}

		public int randomSeed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector3 minOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 maxOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool offsetUseWorldCoords
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 minRotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 maxRotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 rotationOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 minScaleMultiplier
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 maxScaleMultiplier
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool uniformScaleLerp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool shellOffset
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool applyRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool rotateByOffset
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool applyScale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float evaluateOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float minObjectDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxObjectDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ObjectControllerCustomRuleBase customOffsetRule
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ObjectControllerCustomRuleBase customRotationRule
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ObjectControllerCustomRuleBase customScaleRule
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Clear()
		{
		}

		private void OnValidate()
		{
		}

		private void Remove()
		{
		}

		public void GetAll()
		{
		}

		public void Spawn()
		{
		}

		protected override void LateRun()
		{
		}

		[IteratorStateMachine(typeof(_003CInstantiateAllWithDelay_003Ed__116))]
		private IEnumerator InstantiateAllWithDelay()
		{
			return null;
		}

		private void InstantiateAll()
		{
		}

		private void InstantiateSingle()
		{
		}

		protected override void Build()
		{
		}

		protected override void PostBuild()
		{
		}
	}
}
