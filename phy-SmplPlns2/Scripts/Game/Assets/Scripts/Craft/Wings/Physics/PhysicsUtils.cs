using System.Runtime.CompilerServices;
using Assets.Scripts.Craft.MeshGen;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public static class PhysicsUtils
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 GetTorqueFromForce(float3 force, float3 position)
		{
			return math.cross(position, force);
		}

		public static void IntegrateBody(float inverseMass, in float3x3 inverseInertiaTensor, float3 force, float3 torque, float dt, ref float3 velocity, ref float3 angularVelocity, ref RigidTransform transform, float maxAngularVelocity = 7f)
		{
			velocity += force * (inverseMass * dt);
			angularVelocity += math.mul(inverseInertiaTensor, torque * dt);
			angularVelocity = MathUtils.ClampMagnitude(angularVelocity, maxAngularVelocity);
			transform.pos += velocity * dt;
			quaternion a = new quaternion(math.float4(angularVelocity, 0f));
			quaternion rot = transform.rot;
			quaternion quaternion2 = new quaternion(math.mul(a, rot).value * (dt * 0.5f));
			rot.value += quaternion2.value;
			rot = math.normalize(rot);
			transform.rot = rot;
		}

		public static void IntegrateBodyLocal(float inverseMass, in float3x3 inverseInertiaTensorLocal, float3 forceLocal, float3 torqueLocal, float dt, ref float3 velocity, ref float3 angularVelocity, ref RigidTransform transform, float maxAngularVelocity = 7f)
		{
			velocity += math.rotate(transform.rot, forceLocal) * (inverseMass * dt);
			angularVelocity += math.rotate(transform.rot, math.mul(inverseInertiaTensorLocal, torqueLocal * dt));
			angularVelocity = MathUtils.ClampMagnitude(angularVelocity, maxAngularVelocity);
			transform.pos += velocity * dt;
			quaternion a = new quaternion(math.float4(angularVelocity, 0f));
			quaternion rot = transform.rot;
			quaternion quaternion2 = new quaternion(math.mul(a, rot).value * (dt * 0.5f));
			rot.value += quaternion2.value;
			rot = math.normalize(rot);
			transform.rot = rot;
		}

		public static float3x3 CalculateInertiaTensorMatrix(in float3 inertiaTensor, in quaternion inertiaTensorRotation)
		{
			float3x3 b = math.float3x3(math.inverse(inertiaTensorRotation));
			b *= math.float3x3(inertiaTensor.xxx, inertiaTensor.yyy, inertiaTensor.zzz);
			return math.mul(math.float3x3(inertiaTensorRotation), b);
		}

		public static float3x3 CalculateInverseInertiaTensorMatrix(in float3 inertiaTensor, in quaternion inertiaTensorRotation)
		{
			float3 float5 = math.float3((inertiaTensor.x == 0f) ? 0f : (1f / inertiaTensor.x), (inertiaTensor.y == 0f) ? 0f : (1f / inertiaTensor.y), (inertiaTensor.z == 0f) ? 0f : (1f / inertiaTensor.z));
			float3x3 b = math.float3x3(math.inverse(inertiaTensorRotation));
			b *= math.float3x3(float5.xxx, float5.yyy, float5.zzz);
			return math.mul(math.float3x3(inertiaTensorRotation), b);
		}

		public static float3 ComputeSingleFrameAngularVelocity(quaternion from, quaternion to, float dt)
		{
			quaternion quaternion2 = math.mul(math.inverse(from), to);
			float w = quaternion2.value.w;
			float3 v = quaternion2.value.xyz / (w * dt * 0.5f);
			return math.mul(from, v);
		}
	}
}
