using System;
using DV.Utils;
using UnityEngine;

namespace DV.Damage
{
	public class WindowsBreakingController : MonoBehaviour
	{
		private const float WINDOWS_BREAK_DAMAGE_THRESHOLD = 1200f;

		private const float WINDOW_PART_FORCE_MULTIPLIER = 4f;

		private const float WINDOW_PART_TORQUE_MULTIPLIER = 100f;

		[Header("Window")]
		public GameObject brokenWindowsPrefab;

		public GameObject windowsRenderGO;

		public GameObject brokenWindowsRenderGO;

		public GameObject[] windowColliders;

		public AudioClip windowsBreakingAudio;

		[NonSerialized]
		public bool windowsBroken;

		private GameObject brokenWindowsParticlesGO;

		private Rigidbody[] brokenWindowsRbs;

		private bool IsDamageable => Globals.G.GameParams.DamageSensitivityModifier != 0f;

		public event Action WindowsBroken;

		public event Action WindowsRestored;

		private void Awake()
		{
			if (brokenWindowsPrefab == null)
			{
				Debug.LogError("WindowsBreakingController doesn't have 'brokenWindowsPrefab' assigned. Controller can't work properly.", this);
			}
			if (windowsRenderGO == null || brokenWindowsRenderGO == null)
			{
				Debug.LogError("WindowsBreakingController doesn't have 'windowsRenderGO' or 'brokenWindowsRenderGO' assigned. Controller can't work properly.", this);
			}
			if (windowColliders == null || windowColliders.Length == 0)
			{
				Debug.LogError("WindowsBreakingController doesn't have 'windowColliders' assigned. Controller can't work properly.", this);
			}
			if (windowsBreakingAudio == null)
			{
				Debug.LogWarning("WindowsBreakingController doesn't have 'windowsBreakingAudio' assigned. Audio won't be played.", this);
			}
		}

		public void Initialize()
		{
			if (!windowsBroken || !IsDamageable)
			{
				windowsBroken = false;
				SetWindowsRenderState(broken: false);
				PrepareBrokenWindowsForBreaking();
			}
			else
			{
				SetWindowsRenderState(broken: true);
				BreakWindowsLogicPart();
			}
		}

		public void RepairWindows()
		{
			if (windowsBroken)
			{
				SetWindowsRenderState(broken: false);
				PrepareBrokenWindowsForBreaking();
				EnableWindowColliders(set: true);
				windowsBroken = false;
			}
		}

		private void PrepareBrokenWindowsForBreaking()
		{
			Transform parent = brokenWindowsRenderGO.transform.parent;
			brokenWindowsParticlesGO = UnityEngine.Object.Instantiate(brokenWindowsPrefab, parent);
			brokenWindowsParticlesGO.SetActive(value: false);
			brokenWindowsRbs = new Rigidbody[brokenWindowsParticlesGO.transform.childCount];
			for (int i = 0; i < brokenWindowsParticlesGO.transform.childCount; i++)
			{
				Transform child = brokenWindowsParticlesGO.transform.GetChild(i);
				brokenWindowsRbs[i] = child.gameObject.AddComponent<Rigidbody>();
				brokenWindowsRbs[i].mass = 0.3f;
				brokenWindowsRbs[i].angularDrag = 0f;
			}
		}

		private void EnableWindowColliders(bool set)
		{
			GameObject[] array = windowColliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(set);
			}
		}

		private void SetWindowsRenderState(bool broken)
		{
			windowsRenderGO.SetActive(!broken);
			brokenWindowsRenderGO.SetActive(broken);
			(broken ? this.WindowsBroken : this.WindowsRestored)?.Invoke();
		}

		public void OnCollisionDamage(float colDamage, Vector3 forceDirection)
		{
			if (!windowsBroken && colDamage > 1200f)
			{
				BreakWindowsFromCollision(forceDirection);
			}
		}

		public void BreakWindowsFromCollision(Vector3 forceDirection)
		{
			if (!windowsBroken && IsDamageable)
			{
				SetWindowsRenderState(broken: true);
				BreakWindowsLogicPart();
				brokenWindowsParticlesGO.SetActive(value: true);
				Rigidbody[] array = brokenWindowsRbs;
				foreach (Rigidbody obj in array)
				{
					float num = UnityEngine.Random.Range(0.5f, 1f);
					Vector3 force = forceDirection.normalized * 4f * num;
					obj.AddForce(force, ForceMode.Impulse);
					obj.AddTorque(UnityEngine.Random.insideUnitSphere * force.magnitude * 100f, ForceMode.Impulse);
				}
				windowsBreakingAudio.Play(base.transform.position + base.transform.up * 2f, 1f, 1f, 0f, 1.8f, 500f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.collisionGroup, brokenWindowsParticlesGO.transform);
				UnityEngine.Object.Destroy(brokenWindowsParticlesGO, 2f);
			}
		}

		private void BreakWindowsLogicPart()
		{
			EnableWindowColliders(set: false);
			windowsBroken = true;
		}
	}
}
