using System;
using System.Collections;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	[RequireComponent(typeof(AudioListener))]
	internal class AudioListenerVelocityProxy : MonoBehaviour
	{
		private const int ScanAlignment = 4;

		private const int ScanRange = 1024;

		private const int ScanTrials = 16;

		private static readonly FieldInfo CachedPtr = typeof(UnityEngine.Object).GetField("m_CachedPtr", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);

		private static int? _offset;

		private AudioListener _audioListener;

		private Vector3 _lastPosition;

		[SerializeField]
		private bool _printMode;

		private IntPtr? _ptr;

		[SerializeField]
		private Transform _velocityTransform;

		public Transform VelocityProxyTransform
		{
			get
			{
				return _velocityTransform;
			}
			set
			{
				_velocityTransform = value;
			}
		}

		protected void OnDisable()
		{
			GamePlayerLoop.UnregisterPreUpdate(EarlyUpdate);
			GamePlayerLoop.UnregisterPreAudioSystemFixedUpdate(EarlyFixedUpdate);
		}

		protected void OnEnable()
		{
			GamePlayerLoop.RegisterPreUpdate(EarlyUpdate);
			GamePlayerLoop.RegisterPreAudioSystemFixedUpdate(EarlyFixedUpdate);
		}

		protected void Start()
		{
			_audioListener = GetComponent<AudioListener>();
			if (!_offset.HasValue)
			{
				StartCoroutine(FindOffsetCoro());
			}
		}

		private unsafe void DoUpdate()
		{
			if (_velocityTransform == null || !_offset.HasValue)
			{
				return;
			}
			Vector3 position = _velocityTransform.position;
			int value = _offset.Value;
			IntPtr intPtr;
			if (!_ptr.HasValue)
			{
				intPtr = (IntPtr)CachedPtr.GetValue(_audioListener);
				if (!(intPtr != IntPtr.Zero))
				{
					return;
				}
				_ptr = intPtr;
			}
			else
			{
				intPtr = _ptr.Value;
			}
			Vector3 position2 = _audioListener.transform.position;
			Vector3 vector = _lastPosition - position + position2;
			Vector3* ptr = (Vector3*)(void*)(intPtr + value);
			Vector3 vector2 = *ptr;
			*ptr = vector;
			if (_printMode)
			{
				Debug.Log($"delta mine = {_lastPosition - position} delta theirs = {position2 - vector2} (listener = {position2}, proxy = {position}");
			}
			_lastPosition = position;
		}

		private void EarlyFixedUpdate()
		{
			if (_audioListener != null && _audioListener.velocityUpdateMode == AudioVelocityUpdateMode.Fixed)
			{
				DoUpdate();
			}
		}

		private void EarlyUpdate()
		{
			if (_audioListener != null && _audioListener.velocityUpdateMode == AudioVelocityUpdateMode.Dynamic)
			{
				DoUpdate();
			}
		}

		private IEnumerator FindOffsetCoro()
		{
			bool wasEnabled = _audioListener.enabled;
			_audioListener.enabled = false;
			GameObject tempObject = new GameObject("AudioListenerTest");
			try
			{
				AudioListener tempListener = tempObject.AddComponent<AudioListener>();
				tempListener.velocityUpdateMode = AudioVelocityUpdateMode.Dynamic;
				IntPtr listenerPtr = (IntPtr)CachedPtr.GetValue(tempListener);
				Vector3 lastPos = new Vector3(float.NaN, float.NaN, float.NaN);
				UnityEngine.Random.State randomState = UnityEngine.Random.state;
				yield return null;
				SetRandomPosition();
				yield return null;
				int? res = null;
				bool consistent = true;
				int i = 0;
				while (true)
				{
					if (i < 16)
					{
						if (!(tempListener == null))
						{
							int? num = TryFindOffset(listenerPtr, lastPos);
							if (i == 0)
							{
								res = num;
							}
							else if (res != num)
							{
								consistent = false;
							}
							SetRandomPosition();
							yield return null;
							i++;
							continue;
						}
						break;
					}
					if (consistent)
					{
						_offset = res;
						Debug.Log($"Got consistent result: {res}");
					}
					else
					{
						Debug.Log("Got inconsistent result");
					}
					break;
				}
				void SetRandomPosition()
				{
					UnityEngine.Random.state = randomState;
					Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
					randomState = UnityEngine.Random.state;
					if (insideUnitSphere == lastPos || math.any(math.isnan(insideUnitSphere)))
					{
						throw new Exception("Random generator failed");
					}
					tempListener.transform.position = insideUnitSphere;
					lastPos = tempListener.transform.position;
				}
			}
			finally
			{
				AudioListenerVelocityProxy audioListenerVelocityProxy = this;
				UnityEngine.Object.Destroy(tempObject);
				audioListenerVelocityProxy._audioListener.enabled = wasEnabled;
			}
		}

		private unsafe int? TryFindOffset(IntPtr listener, Vector3 match)
		{
			uint3 uint5 = math.asuint(match);
			for (int i = 0; i < 1024; i += 4)
			{
				if (math.all(uint5 == *(uint3*)(void*)(listener + i)))
				{
					return i;
				}
			}
			return null;
		}
	}
}
