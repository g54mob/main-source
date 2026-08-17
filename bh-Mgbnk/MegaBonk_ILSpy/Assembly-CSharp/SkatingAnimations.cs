using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

public class SkatingAnimations : MonoBehaviour
{
	public Animator animator;

	private PlayerMovement playerMovement;

	public AudioSource skateSfx;

	private string lastAnimationName;

	private float maxVolume = 0.15f;

	private float skateVolumeBoost = 1f;

	private float idleThreshold = 1f;

	private Queue<float> speedChangeQueue;

	private Queue<float> rotationChangeQueue;

	private float previousSpeed;

	private Vector3 previousForward;

	private int averageFrameCount;

	private float speedChangeThreshold;

	private float rotationChangeThreshold;

	private float nextKickTime;

	private float minKickInterval;

	private float maxKickInterval;

	private void Awake()
	{
		Transform transform = base.transform;
		Transform root = transform.root;
		PlayerMovement component = root.GetComponent<PlayerMovement>();
		playerMovement = component;
	}

	private void Update()
	{
		//IL_02e8: Invalid comparison between I4 and F4
		//IL_0333: Expected F4, but got I4
		//IL_023a: Invalid comparison between I4 and F4
		//IL_0285: Expected F4, but got I4
		//IL_018c: Invalid comparison between I4 and F4
		//IL_01d7: Expected F4, but got I4
		if (!(playerMovement != null))
		{
			return;
		}
		bool flag = playerMovement.IsTouchingGround();
		Vector3 velocity = playerMovement.GetVelocity();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (flag && velocity.x > idleThreshold)
		{
			if (!skateSfx.isPlaying)
			{
				skateSfx.volume = 0f;
				skateSfx.Play();
			}
			float num3;
			if (15f > velocity.x)
			{
				float num = velocity.x - 1f;
				float num2 = num / 15f;
				num3 = num2 * maxVolume;
			}
			else
			{
				num3 = maxVolume;
			}
			float volume = skateSfx.volume;
			float num4 = num3 * skateVolumeBoost;
			float deltaTime = Time.deltaTime;
			float num5 = deltaTime * 15f;
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			float num6 = num4 - volume;
			float num7 = num6 * num5;
			float volume2 = num7 + volume;
			skateSfx.volume = volume2;
		}
		else if (skateSfx.isPlaying)
		{
			float volume3 = skateSfx.volume;
			float deltaTime2 = Time.deltaTime;
			float num8 = deltaTime2 * 15f;
			if (!(0f > num8))
			{
				if (num8 > 1f)
				{
					num8 = 1f;
				}
			}
			else
			{
				num8 = 0f;
			}
			float num9 = 0f - volume3;
			float num10 = num9 * num8;
			float volume4 = num10 + volume3;
			skateSfx.volume = volume4;
			float volume5 = skateSfx.volume;
			if (!(0.005f < volume5))
			{
				skateSfx.Stop();
			}
		}
		float deltaTime3 = Time.deltaTime;
		float num11 = deltaTime3 * 8f;
		if (!(0f > num11))
		{
			if (num11 > 1f)
			{
				num11 = 1f;
			}
		}
		else
		{
			num11 = 0f;
		}
		float num12 = 1f - skateVolumeBoost;
		float num13 = num12 * num11;
		float num14 = num13 + skateVolumeBoost;
		skateVolumeBoost = num14;
	}

	public void Kick()
	{
		skateVolumeBoost = 3f;
	}

	private unsafe void FixedUpdate()
	{
		//IL_01bd: Expected F4, but got I4
		//IL_068e: Expected O, but got Ref
		//IL_036e: Expected F4, but got O
		//IL_02a8: Expected O, but got Ref
		//IL_02a8: Expected O, but got Ref
		//IL_041a: Expected F4, but got I4
		//IL_0726: Invalid comparison between O and F4
		//IL_079d: Expected O, but got Ref
		//IL_07c0: Expected O, but got F4
		//IL_0946: Expected I, but got O
		//IL_07ff: Expected I, but got O
		//IL_0818: Expected F4, but got O
		//IL_08c7: Invalid comparison between F4 and I4
		//IL_08f0: Expected O, but got I4
		if (!(this.playerMovement != null))
		{
			return;
		}
		PlayerMovement playerMovement = this.playerMovement;
		bool flag = (object)this.playerMovement == null;
		UnityEngine.Object obj = this.playerMovement;
		Vector3 velocity;
		bool flag8;
		if (!flag)
		{
			bool flag2 = (object)playerMovement.rb == null;
			obj = this.playerMovement;
			if (!flag2)
			{
				velocity = playerMovement.rb.velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
				bool flag3 = speedChangeQueue == null;
				obj = (UnityEngine.Object)(object)speedChangeQueue;
				if (!flag3)
				{
					float item = velocity.x - previousSpeed;
					speedChangeQueue.Enqueue(item);
					Queue<float> queue = speedChangeQueue;
					bool flag4 = speedChangeQueue == null;
					obj = (UnityEngine.Object)(object)speedChangeQueue;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rcx_v9 (System.Collections.Generic.Queue`1<System.Single>)+20]");
						if ((nint)0 > (nint)averageFrameCount)
						{
							float num = speedChangeQueue.Dequeue();
						}
						bool flag5 = speedChangeQueue == null;
						obj = (UnityEngine.Object)(object)speedChangeQueue;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808FFA50");
							float num2 = 0f;
							Queue<float>.Enumerator enumerator = default(Queue<float>.Enumerator);
							while (enumerator.MoveNext())
							{
								float current = enumerator.Current;
								num2 += current;
							}
							enumerator.Dispose();
							Queue<float> queue2 = speedChangeQueue;
							bool flag6 = speedChangeQueue == null;
							obj = (UnityEngine.Object)(&enumerator);
							if (!flag6)
							{
								float num3 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v20 (System.Collections.Generic.Queue`1<System.Single>)+20]");
								float num4 = num3 / 0f;
								bool flag7 = !(num4 > speedChangeThreshold);
								flag8 = false;
								if (!flag7)
								{
									flag8 = true;
								}
								if (!(num4 > -0.02f))
								{
									goto IL_06cd;
								}
								Transform transform = base.transform;
								bool flag9 = (object)transform == null;
								obj = this;
								if (!flag9)
								{
									Vector3 position = transform.position;
									obj = GameManager.Instance;
									if ((object)GameManager.Instance != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
										float num5 = default(float);
										Vector3 vector = default(Vector3);
										int layerMask = default(int);
										bool flag10 = Physics.Raycast((Vector3)(&num5), (Vector3)(&vector), out var _, 1.5f, layerMask);
										bool flag11 = !flag10;
										float num6 = 1.5f;
										if (!flag11)
										{
											Vector3 velocity2 = playerMovement.rb.velocity;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
											object obj2 = default(object);
											bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f);
											num6 = 1.5f;
											if (!flag12)
											{
												if (velocity2.y > 1f)
												{
													flag8 = true;
												}
												num6 = 1.5f;
											}
										}
										goto IL_06cd;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0634;
		IL_0634:
		throw new NullReferenceException();
		IL_0a0d:
		Animator animator;
		bool value;
		animator.SetBool("idle", value);
		bool value2;
		if ((object)this.animator != null)
		{
			this.animator.SetBool("kicking", value2);
			return;
		}
		goto IL_0634;
		IL_06cd:
		previousSpeed = velocity.x;
		Transform transform2 = base.transform;
		bool flag13 = (object)transform2 == null;
		obj = this;
		if (!flag13)
		{
			Vector3 forward = transform2.forward;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			bool flag14 = rotationChangeQueue == null;
			obj = (UnityEngine.Object)(object)rotationChangeQueue;
			if (!flag14)
			{
				rotationChangeQueue.Enqueue((float)previousForward);
				Queue<float> queue3 = rotationChangeQueue;
				bool flag15 = rotationChangeQueue == null;
				obj = (UnityEngine.Object)(object)rotationChangeQueue;
				if (!flag15)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rcx_v20 (System.Collections.Generic.Queue`1<System.Single>)+20]");
					if ((nint)0 > (nint)averageFrameCount)
					{
						float num7 = rotationChangeQueue.Dequeue();
					}
					bool flag16 = rotationChangeQueue == null;
					obj = (UnityEngine.Object)(object)rotationChangeQueue;
					if (!flag16)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808FFA50");
						float num8 = 0f;
						Queue<float>.Enumerator enumerator2 = default(Queue<float>.Enumerator);
						while (enumerator2.MoveNext())
						{
							float current2 = enumerator2.Current;
							num8 += current2;
						}
						enumerator2.Dispose();
						Queue<float> queue4 = rotationChangeQueue;
						bool flag17 = rotationChangeQueue == null;
						obj = (UnityEngine.Object)(&enumerator2);
						if (!flag17)
						{
							float num9 = num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rax_v32 (System.Collections.Generic.Queue`1<System.Single>)+20]");
							float num10 = num9 / 0f;
							bool flag18 = !(num10 > rotationChangeThreshold);
							value2 = flag8;
							if (!flag18)
							{
								value2 = true;
							}
							previousForward = (Vector3)forward.x;
							_ = forward.z;
							float time = Time.time;
							float num21;
							if (!(time < nextKickTime))
							{
								bool flag19 = (object)this.playerMovement == null;
								obj = null;
								if (flag19)
								{
									goto IL_0634;
								}
								Vector3 wishDir = this.playerMovement.GetWishDir();
								nint num11 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1018 @ rax_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num12 = 0;
								float num13 = (float)Vector3.zeroVector;
								float num14 = wishDir.x - (float)Vector3.zeroVector;
								object obj4 = default(object);
								object obj5 = default(object);
								object obj3 = obj4 - obj5;
								float num15 = wishDir.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rcx_v40 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								float num16 = num15 - 0f;
								object obj6 = obj3 * obj3;
								float num17 = num14 * num14;
								float num18 = (float)obj6 + num17;
								float num19 = num16 * num16;
								float num6 = num18 + num19;
								bool flag20 = 9.9999994E-11f < num6;
								float num20 = 9.9999994E-11f - num6;
								bool flag21 = num20 == 0f;
								bool flag22 = !flag20;
								bool flag23 = !flag21;
								object obj7 = flag23 & flag22;
								bool flag24 = obj7 != null;
								num21 = 9.9999994E-11f;
								if (!flag24)
								{
									float time2 = Time.time;
									num13 = maxKickInterval;
									float num22 = UnityEngine.Random.Range(minKickInterval, maxKickInterval);
									float num23 = num22 + time2;
									nextKickTime = num23;
									num21 = 9.9999994E-11f;
									value2 = true;
									obj = null;
								}
							}
							else
							{
								num21 = 9.9999994E-11f;
								float num24 = default(float);
								float num13 = num24;
								obj = null;
							}
							if ((object)this.playerMovement != null)
							{
								Vector3 wishDir2 = this.playerMovement.GetWishDir();
								nint num25 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rax_v36 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num26 = 0;
								float num27 = wishDir2.x - (float)Vector3.zeroVector;
								float num28 = wishDir2.y;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1080 @ rcx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
								float num29 = num28 - 0f;
								float num30 = wishDir2.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1080 @ rcx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								float num31 = num30 - 0f;
								float num32 = num29 * num29;
								float num33 = num27 * num27;
								float num34 = num32 + num33;
								float num35 = num31 * num31;
								float num36 = num34 + num35;
								if (num21 > num36)
								{
									Vector3 velocity3 = playerMovement.rb.velocity;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
									if (idleThreshold > velocity3.x)
									{
										if ((object)this.animator == null)
										{
											goto IL_0634;
										}
										value = true;
										animator = this.animator;
										goto IL_0a0d;
									}
								}
								if ((object)this.animator != null)
								{
									value = false;
									animator = this.animator;
									goto IL_0a0d;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0634;
	}

	public SkatingAnimations()
	{
		Queue<float> queue = new Queue<float>();
		speedChangeQueue = queue;
		rotationChangeQueue = new Queue<float>();
		averageFrameCount = 10;
		speedChangeThreshold = 0.06f;
		rotationChangeThreshold = 2f;
		minKickInterval = 0.5f;
		maxKickInterval = 1.5f;
		base._002Ector();
	}
}
