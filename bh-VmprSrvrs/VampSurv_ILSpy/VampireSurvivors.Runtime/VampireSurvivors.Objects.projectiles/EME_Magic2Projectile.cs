using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_Magic2Projectile : EME_Magic1Projectile
{
	private float _hitboxOrbitSpeed;

	private float _vfxPositionInCircumference;

	private float _angleTravelled;

	private const float RadiansInAFullCircle = (float)Math.PI * 2f;

	protected override float OrbitSpeed => _hitboxOrbitSpeed * ((float)Math.PI / 180f);

	public unsafe override void InternalUpdate()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Ref, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Ref, but got Unknown
		//IL_0186: Expected I, but got O
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_01dd->IL01e2: Incompatible stack heights: 4 vs 0
		//IL_00e7->IL01e2: Incompatible stack heights: 5 vs 0
		if (_activate)
		{
			Transform cachedTransform = _cachedTransform;
			float orbitSpeed = OrbitSpeed;
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float orbitSpeed2 = deltaTime * (float)obj;
			Vector3 vector = OrbitPositionAroundPlayer(ref *(float*)(this + 272), orbitSpeed2);
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
			bool flag2 = (object)_chosenSpiritRing == null;
			Transform transform = _chosenSpiritRing.transform;
			Vector3 vector2 = OrbitPositionAroundPlayer(ref *(float*)(this + 292), 0f);
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			nint num = (nint)this;
			float orbitSpeed3 = OrbitSpeed;
			float x = vector2.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = x & 0;
			if (!((_angleTravelled = (float)obj2 + _angleTravelled) < (float)Math.PI * 2f))
			{
				bool flag5 = _objectsHit == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				_angleTravelled = 0f;
			}
		}
	}

	public override void SetOffsetPosition(int index)
	{
		base.SetOffsetPosition(index);
		_vfxPositionInCircumference = _positionInCircumference;
	}

	public EME_Magic2Projectile()
	{
		base._defaultOrbitRadius = 0.5f;
		base._maximumOrbitRadius = 4.5f;
		base._defaultHitboxRadius = 10f;
		((Projectile)this)._002Ector();
	}
}
