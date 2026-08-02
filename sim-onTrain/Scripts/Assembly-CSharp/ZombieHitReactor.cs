using System.Collections;
using System.Collections.Generic;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

public class ZombieHitReactor : MonoBehaviour
{
	[Tooltip("Canlı zombide vuruş anında FİZİK reaksiyonu (ragdoll impulse/blend) uygulansın mı? KAPALI (önerilen) = sadece animasyon flinch oynar, lastik/titreme İMKANSIZ. Açık = eski fizik-impulse sistemi (tuning gerektirir). Ölüm ragdoll'u bu ayardan bağımsız her zaman çalışır.")]
	public bool usePhysicsHitReaction;

	[Range(1f, 60f)]
	[Tooltip("Vurulan kemiğe uygulanacak kuvvet. Yüksek = daha çok geri gider. Sadece Use Physics Hit Reaction açıkken etkili.")]
	public float hitImpulseForce = 30f;

	[Range(0.05f, 0.3f)]
	[Tooltip("Impulse süresi (FIMSpace önerisi: 0.1-0.2)")]
	public float hitImpulseDuration = 0.15f;

	[Range(0f, 1f)]
	[Tooltip("Vurulan kemiğin blend spike değeri")]
	public float hitBoneBlend = 1f;

	[Range(0f, 1f)]
	[Tooltip("Zincirdeki komşu kemiklerin blend değeri (falloff)")]
	public float neighborBoneBlend = 0.5f;

	[Range(0.2f, 2f)]
	[Tooltip("Blend'in 0'a dönüş süresi. Uzun = fizikten animasyona daha yumuşak geçiş (ani snap olmaz). Yayın oturması için damping ile uyumlu tut.")]
	public float blendRecoveryTime = 0.65f;

	public float headMultiplier = 1.8f;

	public float spineMultiplier = 1f;

	public float armMultiplier = 1.2f;

	public float legMultiplier = 1.3f;

	[Tooltip("Ölümde tüm gövdeye uygulanan genel itme (acceleration). Yumuşak savrulma için düşük tut.")]
	public float deathBodyPushPower = 0.4f;

	[Range(0f, 8f)]
	[Tooltip("Ölümde son vuruş yönünde kalçaya verilen hız (m/s). Hafif geriye yığılma için düşük tut.")]
	public float deathLaunchSpeed = 1.5f;

	[Range(0.05f, 0.6f)]
	[Tooltip("Ölüm impulse süresi — yüksek = daha yumuşak/yayvan savrulma.")]
	public float deathImpactDuration = 0.25f;

	[Range(0f, 1f)]
	[Tooltip("Ölümde anchor spring değeri — düşük tut ki gövde spring kuvvetiyle bir anda fırlamasın.")]
	public float deathAnchorSpring = 0.05f;

	[Tooltip("Kas yayı. Yüksek = hızlı/sert toparlanma, düşük = gevşek. Düşürünce overshoot (lastik) azalır.")]
	public float springsValue = 900f;

	[Tooltip("Sönümleme (joint drive). Yüksek = titreşim/lastik gider. Ama yüksek frekanslı salınımı tam kesmez — onun için Angular Drag kullan.")]
	public float dampingValue = 160f;

	[Range(0f, 20f)]
	[Tooltip("Kemik rigidbody açısal sürtünmesi. Pasif sönümleme. RA2 varsayılanı 0.2 (çok düşük).")]
	public float angularDrag = 6f;

	[Range(0f, 1f)]
	[Tooltip("SALLANMANIN GERÇEK ÇÖZÜMÜ. Reaksiyon anında her fizik adımında kemiğin AÇISAL hızından silinen oran. 0 = kapalı (serbest sallanır), 0.6 = tek savrulup durur, 0.85 = çok sert/anında durur. Linear itmeye (geri gitme) dokunmaz.")]
	public float reactionAngularDamp = 0.6f;

	[Range(0f, 2f)]
	[Tooltip("Genel kas gücü çarpanı.")]
	public float musclesPower = 1f;

	[Tooltip("Ölüm/fall modunda kas. Düşük = gevşek ragdoll. 0 YAPMA — kod 0'ı SpringsValue'ya (katı) çevirir.")]
	public float springsOnFall = 5f;

	[Tooltip("Bone başına Unity solver iterasyonu. Düşük = ucuz (çok zombide önemli). 6 yeterli.")]
	public int unitySolverIterations = 6;

	[Tooltip("Kemik rigidbody interpolation'ı. Interpolate = düşük fizik hızında titreme/lastik hissini keser. None = değiştirme.")]
	public RigidbodyInterpolation boneInterpolation = RigidbodyInterpolation.Interpolate;

	[Tooltip("RagdollAnimator2 init olana kadar maksimum bekleme (sn).")]
	public float maxWaitForInit = 3f;

	[Range(0.05f, 1f)]
	public float hitCooldown = 0.4f;

	[Range(0f, 0.5f)]
	[Tooltip("Cooldown içindeki vuruşlarda kuvvet çarpanı")]
	public float rapidFireForceDampen = 0.2f;

	private static readonly bool USE_PROCEDURAL_HIT_REACT = true;

	private const float REACT_ANGLE = 70f;

	private const float REACT_DURATION = 0.18f;

	private const float ARM_REACT_DURATION = 0.24f;

	private const float REACT_RISE = 0.05f;

	private const float LIMB_ANGLE_MULT = 3f;

	private const float LIMB_TORSO_RATIO = 0.5f;

	private const float LEG_REACT_DURATION = 0.45f;

	private const float LEG_REACT_RISE = 0.18f;

	private const float LEG_ANGLE_MULT = 1.3f;

	private const float UPPER_LIMB_FACTOR = 0.5f;

	public bool ragdollReady;

	private RagdollAnimator2 _ragdoll;

	private RagdollChainBone _anchorBone;

	private bool _reactActive;

	private float _reactTimer;

	private Vector3 _reactAxisWorld;

	private ERagdollChainType _reactChain = ERagdollChainType.Core;

	private int _reactStartBone;

	private bool _reactUpper;

	private Dictionary<RagdollChainBone, Coroutine> _boneCoroutines = new Dictionary<RagdollChainBone, Coroutine>();

	private float _lastHitTime;

	private readonly List<RagdollChainBone> _bendBuffer = new List<RagdollChainBone>();

	private bool _fullRagdollActive;

	private IEnumerator Start()
	{
		_ragdoll = GetComponentInChildren<RagdollAnimator2>();
		if (_ragdoll == null)
		{
			Debug.LogWarning("[ZombieHitReactor] '" + base.name + "' — RagdollAnimator2 bulunamadı!");
			yield break;
		}
		float t = 0f;
		while ((_ragdoll.Handler == null || !_ragdoll.Handler.WasInitialized) && t < maxWaitForInit)
		{
			t += Time.deltaTime;
			yield return null;
		}
		ragdollReady = true;
		_ragdoll.RagdollBlend = 1f;
		ZeroAllBones();
		_ragdoll.Handler.AnchorBoneSpring = 1f;
		_anchorBone = _ragdoll.Handler.GetAnchorBoneController;
		IgnoreSelfCollisions();
		ApplyMuscleSettings();
	}

	public void ApplyMuscleSettings()
	{
		if (_ragdoll == null)
		{
			return;
		}
		RagdollHandler handler = _ragdoll.Handler;
		if (handler == null)
		{
			return;
		}
		handler.SpringsValue = springsValue;
		handler.DampingValue = dampingValue;
		handler.MusclesPower = musclesPower;
		handler.SpringsOnFall = springsOnFall;
		handler.UnitySolverIterations = unitySolverIterations;
		handler.RigidbodyAngularDragValue = angularDrag;
		handler.User_UpdateJointsPlayParameters(reset: false);
		if (handler.Chains == null)
		{
			return;
		}
		foreach (RagdollBonesChain chain in handler.Chains)
		{
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				if (boneSetup.GameRigidbody != null)
				{
					boneSetup.GameRigidbody.solverIterations = unitySolverIterations;
					boneSetup.GameRigidbody.angularDrag = angularDrag;
					if (boneInterpolation != RigidbodyInterpolation.None)
					{
						boneSetup.GameRigidbody.interpolation = boneInterpolation;
					}
				}
			}
		}
	}

	public void TriggerProceduralReact(Vector3 hitDir, BodyHitPart hitPart = BodyHitPart.Spine)
	{
		if (!USE_PROCEDURAL_HIT_REACT)
		{
			return;
		}
		hitDir.y = 0f;
		if (!(hitDir.sqrMagnitude < 0.0001f))
		{
			hitDir.Normalize();
			_reactAxisWorld = Vector3.Cross(Vector3.up, hitDir);
			if (!(_reactAxisWorld.sqrMagnitude < 0.0001f))
			{
				_reactAxisWorld.Normalize();
				_reactChain = GetChainType(hitPart);
				_reactUpper = IsUpperPart(hitPart);
				_reactStartBone = ((!_reactUpper) ? 1 : 0);
				_reactTimer = 0f;
				_reactActive = true;
				Debug.Log($"[PROC_REACT] part={hitPart} chain={_reactChain} upper={IsUpperPart(hitPart)} obj={base.name}");
			}
		}
	}

	private void LateUpdate()
	{
		if (!_reactActive)
		{
			return;
		}
		if (_fullRagdollActive)
		{
			_reactActive = false;
			return;
		}
		bool flag = _reactChain == ERagdollChainType.LeftLeg || _reactChain == ERagdollChainType.RightLeg;
		bool flag2 = _reactChain == ERagdollChainType.LeftArm || _reactChain == ERagdollChainType.RightArm;
		float num = (flag ? 0.45f : (flag2 ? 0.24f : 0.18f));
		float num2 = (flag ? 0.18f : 0.05f);
		_reactTimer += Time.deltaTime;
		float num3 = _reactTimer / num;
		if (num3 >= 1f)
		{
			_reactActive = false;
			return;
		}
		float num4 = ((num3 < num2) ? Mathf.SmoothStep(0f, 1f, num3 / num2) : Mathf.SmoothStep(1f, 0f, (num3 - num2) / (1f - num2)));
		float num5 = 70f * num4;
		if (!(Mathf.Abs(num5) < 0.01f))
		{
			if (_reactChain == ERagdollChainType.Core)
			{
				ApplyChainBend(ERagdollChainType.Core, num5);
				return;
			}
			float num6 = (flag ? 1.3f : 3f);
			float num7 = (flag ? (-1f) : 1f);
			float num8 = (_reactUpper ? 0.5f : 1f);
			ApplyChainBend(_reactChain, num5 * num6 * num7 * num8, _reactStartBone);
			ApplyChainBend(ERagdollChainType.Core, num5 * 0.5f * num8);
		}
	}

	private void ApplyChainBend(ERagdollChainType chainType, float totalAngle, int startBone = 0)
	{
		if (_ragdoll == null || _ragdoll.Handler == null)
		{
			return;
		}
		RagdollBonesChain chain = _ragdoll.Handler.GetChain(chainType);
		if (chain == null || chain.BoneSetups.Count == 0)
		{
			Debug.LogWarning($"[PROC_REACT] '{base.name}' — {chainType} zinciri bulunamadı, bükme atlandı!");
			return;
		}
		_bendBuffer.Clear();
		foreach (RagdollChainBone boneSetup in chain.BoneSetups)
		{
			if (boneSetup != _anchorBone && boneSetup.SourceBone != null)
			{
				_bendBuffer.Add(boneSetup);
			}
		}
		if (_bendBuffer.Count != 0)
		{
			int num = Mathf.Clamp(startBone, 0, _bendBuffer.Count - 1);
			int num2 = _bendBuffer.Count - num;
			Quaternion quaternion = Quaternion.AngleAxis(totalAngle / (float)num2, _reactAxisWorld);
			for (int i = num; i < _bendBuffer.Count; i++)
			{
				_bendBuffer[i].SourceBone.rotation = quaternion * _bendBuffer[i].SourceBone.rotation;
			}
		}
	}

	private void IgnoreSelfCollisions()
	{
		List<Collider> list = new List<Collider>();
		foreach (RagdollBonesChain chain in _ragdoll.Handler.Chains)
		{
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				if (boneSetup.PhysicalDummyBone != null)
				{
					list.AddRange(boneSetup.PhysicalDummyBone.GetComponents<Collider>());
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				Physics.IgnoreCollision(list[i], list[j], ignore: true);
			}
		}
		Collider[] components = GetComponents<Collider>();
		CharacterController component = GetComponent<CharacterController>();
		for (int k = 0; k < list.Count; k++)
		{
			if (component != null)
			{
				Physics.IgnoreCollision(list[k], component, ignore: true);
			}
			for (int l = 0; l < components.Length; l++)
			{
				if (!(components[l] == null) && !(components[l] == component))
				{
					Physics.IgnoreCollision(list[k], components[l], ignore: true);
				}
			}
		}
	}

	private void FixedUpdate()
	{
		if (_ragdoll == null || !ragdollReady || _fullRagdollActive)
		{
			return;
		}
		if (reactionAngularDamp > 0f && _boneCoroutines.Count > 0)
		{
			float num = 1f - reactionAngularDamp;
			foreach (KeyValuePair<RagdollChainBone, Coroutine> boneCoroutine in _boneCoroutines)
			{
				Rigidbody rigidbody = boneCoroutine.Key?.GameRigidbody;
				if (rigidbody != null && !rigidbody.isKinematic)
				{
					rigidbody.angularVelocity *= num;
				}
			}
		}
		RagdollChainBone getAnchorBoneController = _ragdoll.Handler.GetAnchorBoneController;
		if (!(getAnchorBoneController?.GameRigidbody == null) && !getAnchorBoneController.GameRigidbody.isKinematic)
		{
			getAnchorBoneController.GameRigidbody.velocity = Vector3.zero;
		}
	}

	private void ZeroAllBones()
	{
		foreach (RagdollBonesChain chain in _ragdoll.Handler.Chains)
		{
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				boneSetup.BoneBlendMultiplier = 0f;
			}
		}
	}

	public void ApplyHitImpulse(BodyHitPart hitPart, Vector3 hitDirection, Vector3 hitPoint)
	{
		if (!usePhysicsHitReaction || _ragdoll == null)
		{
			return;
		}
		float num = ((Time.time - _lastHitTime < hitCooldown) ? rapidFireForceDampen : 1f);
		_lastHitTime = Time.time;
		float num2 = hitImpulseForce * GetMultiplier(hitPart) * num;
		Vector3 velocity = hitDirection.normalized * num2;
		ERagdollChainType chainType = GetChainType(hitPart);
		RagdollChainBone ragdollChainBone = _ragdoll.User_GetNearestRagdollBoneControllerToPosition(hitPoint, fast: true, chainType);
		if (ragdollChainBone == null)
		{
			return;
		}
		if (ragdollChainBone != _anchorBone)
		{
			_ragdoll.User_AddBoneImpact(ragdollChainBone, velocity, hitImpulseDuration, ForceMode.VelocityChange);
		}
		SpikeBone(ragdollChainBone, hitBoneBlend);
		RagdollBonesChain chain = _ragdoll.Handler.GetChain(chainType);
		if (chain == null)
		{
			return;
		}
		foreach (RagdollChainBone boneSetup in chain.BoneSetups)
		{
			if (boneSetup != ragdollChainBone)
			{
				SpikeBone(boneSetup, neighborBoneBlend);
			}
		}
	}

	private void SpikeBone(RagdollChainBone bone, float targetBlend)
	{
		if (bone != _anchorBone)
		{
			SpikeBoneInternal(bone, targetBlend);
		}
	}

	private void SpikeBoneInternal(RagdollChainBone bone, float targetBlend)
	{
		if (_boneCoroutines.TryGetValue(bone, out var value) && value != null)
		{
			StopCoroutine(value);
		}
		_boneCoroutines[bone] = StartCoroutine(BoneBlendDecay(bone, targetBlend));
	}

	private IEnumerator BoneBlendDecay(RagdollChainBone bone, float startBlend)
	{
		bone.BoneBlendMultiplier = startBlend;
		float elapsed = 0f;
		while (elapsed < blendRecoveryTime)
		{
			elapsed += Time.deltaTime;
			bone.BoneBlendMultiplier = Mathf.Lerp(startBlend, 0f, elapsed / blendRecoveryTime);
			yield return null;
		}
		bone.BoneBlendMultiplier = 0f;
		_boneCoroutines.Remove(bone);
	}

	public void EnableFullRagdoll(Vector3 deathForceDir)
	{
		if (_ragdoll == null)
		{
			return;
		}
		_fullRagdollActive = true;
		_ragdoll.Handler.AnchorBoneSpring = deathAnchorSpring;
		foreach (RagdollBonesChain chain in _ragdoll.Handler.Chains)
		{
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				boneSetup.BoneBlendMultiplier = 1f;
			}
		}
		Vector3 impactDirection = ((deathForceDir.sqrMagnitude > 0.0001f) ? deathForceDir.normalized : Vector3.forward);
		_ragdoll.User_FallImpact(impactDirection, deathLaunchSpeed, deathImpactDuration, deathBodyPushPower, _anchorBone?.GameRigidbody);
	}

	public void SetRagdollCollidersToLayer(int layer)
	{
		if (_ragdoll == null || _ragdoll.Handler == null || _ragdoll.Handler.Chains == null)
		{
			return;
		}
		foreach (RagdollBonesChain chain in _ragdoll.Handler.Chains)
		{
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				if (boneSetup.PhysicalDummyBone != null)
				{
					Collider[] components = boneSetup.PhysicalDummyBone.GetComponents<Collider>();
					for (int i = 0; i < components.Length; i++)
					{
						components[i].gameObject.layer = layer;
					}
				}
			}
		}
	}

	public void DisableRagdoll()
	{
		if (_ragdoll == null)
		{
			return;
		}
		foreach (KeyValuePair<RagdollChainBone, Coroutine> boneCoroutine in _boneCoroutines)
		{
			if (boneCoroutine.Value != null)
			{
				StopCoroutine(boneCoroutine.Value);
			}
		}
		_boneCoroutines.Clear();
		_fullRagdollActive = false;
		ZeroAllBones();
		_ragdoll.User_TransitionToStandingMode(0.4f, 0f);
	}

	private ERagdollChainType GetChainType(BodyHitPart hitPart)
	{
		switch (hitPart)
		{
		case BodyHitPart.LeftArm:
		case BodyHitPart.UpperLeftArm:
			return ERagdollChainType.LeftArm;
		case BodyHitPart.RightArm:
		case BodyHitPart.UpperRightArm:
			return ERagdollChainType.RightArm;
		case BodyHitPart.LeftLeg:
		case BodyHitPart.UpperLeftLeg:
			return ERagdollChainType.LeftLeg;
		case BodyHitPart.RightLeg:
		case BodyHitPart.UpperRightLeg:
			return ERagdollChainType.RightLeg;
		default:
			return ERagdollChainType.Core;
		}
	}

	private static bool IsUpperPart(BodyHitPart p)
	{
		if (p != BodyHitPart.UpperLeftArm && p != BodyHitPart.UpperRightArm && p != BodyHitPart.UpperLeftLeg)
		{
			return p == BodyHitPart.UpperRightLeg;
		}
		return true;
	}

	private float GetMultiplier(BodyHitPart hitPart)
	{
		switch (hitPart)
		{
		case BodyHitPart.Head:
			return headMultiplier;
		case BodyHitPart.Spine:
			return spineMultiplier;
		case BodyHitPart.RightArm:
		case BodyHitPart.LeftArm:
			return armMultiplier;
		case BodyHitPart.RightLeg:
		case BodyHitPart.LeftLeg:
			return legMultiplier;
		default:
			return 1f;
		}
	}
}
