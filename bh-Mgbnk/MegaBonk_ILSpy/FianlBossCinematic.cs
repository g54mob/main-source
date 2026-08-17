using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;

public class FianlBossCinematic : MonoBehaviour
{
	private sealed class _003CAnimateCinematic_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FianlBossCinematic _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateCinematic_003Ed__14(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_047b: Expected I4, but got I8
			//IL_061d: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_03e5: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_02c7: Expected I4, but got I8
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_00cc: Expected I4, but got I8
			//IL_066d: Expected O, but got Ref
			//IL_008a: Expected I4, but got I8
			//IL_0330: Expected O, but got Ref
			//IL_0330: Expected O, but got Ref
			//IL_0255: Expected O, but got Ref
			FianlBossCinematic fianlBossCinematic = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					object obj4 = default(object);
					if (!flag)
					{
						object obj3 = obj2 - 1;
						if (!flag)
						{
							if ((nint)obj3 == 1)
							{
								_003C_003E1__state = -1;
								if ((object)MusicController.Instance == null)
								{
									goto IL_060f;
								}
								MusicController.Instance.PlayStageMusic();
							}
							return false;
						}
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null && (object)fianlBossCinematic.cameraCircling != null)
						{
							Transform parent = fianlBossCinematic.cameraCircling.parent;
							if ((object)parent != null)
							{
								GameObject gameObject = parent.gameObject;
								if ((object)gameObject != null)
								{
									gameObject.SetActive(value: false);
									if ((object)PlayerCamera.Instance != null)
									{
										GameObject gameObject2 = PlayerCamera.Instance.gameObject;
										if ((object)gameObject2 != null)
										{
											gameObject2.SetActive(value: true);
											fianlBossCinematic.target = null;
											if ((object)fianlBossCinematic.cameraCirclingCamera != null)
											{
												fianlBossCinematic.cameraCirclingCamera.fieldOfView = 85f;
												if ((object)fianlBossCinematic.cameraCircling != null)
												{
													Transform transform = fianlBossCinematic.cameraCircling.transform;
													if ((object)transform != null)
													{
														transform.localRotation = (Quaternion)(&obj4);
														if ((object)fianlBossCinematic.finalFightController != null)
														{
															fianlBossCinematic.finalFightController.SpawnBoss();
															WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
															_003C_003E2__current = waitForSeconds;
															_003C_003E1__state = 4;
															goto IL_0676;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					else
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null)
						{
							MapGenerationFinalBoss mapGeneration = fianlBossCinematic.mapGeneration;
							if ((object)fianlBossCinematic.mapGeneration != null)
							{
								Quaternion quaternion = Quaternion.LookRotation((Vector3)(&obj4));
								object obj5 = default(object);
								GameObject gameObject3 = UnityEngine.Object.Instantiate(mapGeneration.spawnPortal, (Vector3)(&obj4), (Quaternion)(&obj5));
								if ((object)gameObject3 != null)
								{
									SpawnPlayerPortal component = gameObject3.GetComponent<SpawnPlayerPortal>();
									if ((object)component != null)
									{
										component.StartPortal();
										Transform transform2 = gameObject3.transform;
										fianlBossCinematic.target = transform2;
										WaitForSeconds waitForSeconds2 = new WaitForSeconds(1.5f);
										_003C_003E2__current = waitForSeconds2;
										_003C_003E1__state = 3;
										goto IL_0676;
									}
								}
							}
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)fianlBossCinematic.meteor != null)
					{
						fianlBossCinematic.meteor.SetActive(value: true);
						WaitForSeconds waitForSeconds3 = new WaitForSeconds(4f);
						_003C_003E2__current = waitForSeconds3;
						_003C_003E1__state = 2;
						goto IL_0676;
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				GameManager instance = GameManager.Instance;
				if ((object)GameManager.Instance != null)
				{
					instance.cutscene = true;
					UiManager instance2 = UiManager.Instance;
					if ((object)UiManager.Instance != null && (object)instance2.cinematicBars != null)
					{
						instance2.cinematicBars.InstaShow();
						if ((object)PlayerCamera.Instance != null)
						{
							GameObject gameObject4 = PlayerCamera.Instance.gameObject;
							if ((object)gameObject4 != null)
							{
								gameObject4.SetActive(value: false);
								if ((object)_003C_003E4__this != null && (object)fianlBossCinematic.cameraCircling != null)
								{
									GameObject gameObject5 = fianlBossCinematic.cameraCircling.gameObject;
									if ((object)gameObject5 != null)
									{
										gameObject5.SetActive(value: true);
										WaitForSeconds waitForSeconds4 = new WaitForSeconds(1.5f);
										_003C_003E2__current = waitForSeconds4;
										_003C_003E1__state = 1;
										goto IL_0676;
									}
								}
							}
						}
					}
				}
			}
			goto IL_060f;
			IL_0676:
			return true;
			IL_060f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public bool skipIntro = true;

	public MapGenerationFinalBoss mapGeneration;

	public Transform cameraCircling;

	public Camera cameraCirclingCamera;

	public FinalFightController finalFightController;

	public GameObject meteor;

	public ShakePreset impactShake;

	public Shaker shaker;

	private float cameraRotationSpeed;

	private float fovSpeed = 0.5f;

	private float desiredFov = 10f;

	private Transform target;

	public GameObject finalPortal;

	public void Start()
	{
		//IL_00ed: Expected I, but got O
		//IL_00c5: Expected I, but got O
		_003CAnimateCinematic_003Ed__14 obj = new _003CAnimateCinematic_003Ed__14(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		Action<bool> b = OnStageBossDied;
		Delegate obj2 = Delegate.Combine(FinalFightController.A_BossDefeated, b);
		if ((object)obj2 == null)
		{
			FinalFightController.A_BossDefeated = (Action<bool>)obj2;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			FinalFightController.A_BossDefeated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj3 = default(object);
			bool flag = obj3 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> value = OnStageBossDied;
		Delegate obj = Delegate.Remove(FinalFightController.A_BossDefeated, value);
		if ((object)obj == null)
		{
			FinalFightController.A_BossDefeated = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			FinalFightController.A_BossDefeated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private IEnumerator AnimateCinematic()
	{
		_003CAnimateCinematic_003Ed__14 obj = new _003CAnimateCinematic_003Ed__14(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void Impact()
	{
		//IL_0016: Expected O, but got I4
		ShakeInstance shakeInstance = shaker.Shake(impactShake, (int?)(object)0);
	}

	private void OnStageBossDied(bool idk)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172AC3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("SpawnPortal", 10f);
	}

	private void SpawnPortal()
	{
		finalPortal.SetActive(value: true);
	}

	private unsafe void Update()
	{
		//IL_0061: Invalid comparison between I4 and F4
		//IL_00ac: Expected F4, but got I4
		//IL_00be: Expected O, but got Ref
		//IL_015c: Invalid comparison between I4 and F4
		//IL_01a7: Expected F4, but got I4
		//IL_0225: Expected O, but got Ref
		//IL_0259: Expected O, but got Ref
		//IL_0259: Expected O, but got Ref
		//IL_026f: Expected O, but got Ref
		Transform transform = cameraCircling.transform;
		Transform transform2 = cameraCircling.transform;
		Vector3 localPosition = transform2.localPosition;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 0.25f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localPosition = (Vector3)(&num2);
		if (!(target != null))
		{
			return;
		}
		GameObject gameObject = target.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			return;
		}
		float fieldOfView = cameraCirclingCamera.fieldOfView;
		float deltaTime2 = Time.deltaTime;
		float num3 = deltaTime2 * 3f;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = desiredFov - fieldOfView;
		float num5 = num4 * num3;
		float fieldOfView2 = num5 + fieldOfView;
		cameraCirclingCamera.fieldOfView = fieldOfView2;
		Transform transform3 = cameraCircling.transform;
		Transform transform4 = cameraCircling.transform;
		Quaternion rotation = transform4.rotation;
		Vector3 position = target.position;
		Transform transform5 = cameraCircling.transform;
		Vector3 position2 = transform5.position;
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num2));
		float deltaTime3 = Time.deltaTime;
		float t = deltaTime3 * 3f;
		float num6 = default(float);
		Quaternion quaternion2 = Quaternion.Lerp((Quaternion)(&num2), (Quaternion)(&num6), t);
		transform3.rotation = (Quaternion)(&num6);
	}
}
