using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct ForceJacobian
	{
		public float3x3 d_force_ang;

		public float3x3 d_force_vel;

		public float3x3 d_torque_ang;

		public float3x3 d_torque_vel;

		public float3 force;

		public float3 torque;

		public static ForceJacobian operator *(ForceJacobian a, float b)
		{
			a.force *= b;
			a.torque *= b;
			a.d_force_vel *= b;
			a.d_force_ang *= b;
			a.d_torque_vel *= b;
			a.d_torque_ang *= b;
			return a;
		}

		public static ForceJacobian operator +(ForceJacobian lhs, ForceJacobian rhs)
		{
			return new ForceJacobian
			{
				force = lhs.force + rhs.force,
				torque = lhs.torque + rhs.torque,
				d_force_vel = lhs.d_force_vel + rhs.d_force_vel,
				d_force_ang = lhs.d_force_ang + rhs.d_force_ang,
				d_torque_vel = lhs.d_torque_vel + rhs.d_torque_vel,
				d_torque_ang = lhs.d_torque_ang + rhs.d_torque_ang
			};
		}

		public void AdjustForPosition(float3 position)
		{
			float3x3 b = math.float3x3(math.float3(0f, 0f - position.z, position.y), math.float3(position.z, 0f, 0f - position.x), math.float3(0f - position.y, position.x, 0f));
			d_force_ang += math.mul(d_force_vel, b);
			d_torque_ang += math.mul(d_torque_vel, b);
			Adjust(ref torque, in force);
			Adjust(ref d_torque_vel.c0, in d_force_vel.c0);
			Adjust(ref d_torque_vel.c1, in d_force_vel.c1);
			Adjust(ref d_torque_vel.c2, in d_force_vel.c2);
			Adjust(ref d_torque_ang.c0, in d_force_ang.c0);
			Adjust(ref d_torque_ang.c1, in d_force_ang.c1);
			Adjust(ref d_torque_ang.c2, in d_force_ang.c2);
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			void Adjust(ref float3 torque, in float3 force)
			{
				torque += PhysicsUtils.GetTorqueFromForce(force, position);
			}
		}

		public readonly void GetAdjustedValues(float3 deltaVel, float3 deltaAng, out float3 force, out float3 torque)
		{
			force = this.force;
			force += math.mul(d_force_vel, deltaVel);
			force += math.mul(d_force_ang, deltaAng);
			torque = this.torque;
			torque += math.mul(d_torque_vel, deltaVel);
			torque += math.mul(d_torque_ang, deltaAng);
		}

		public override readonly string ToString()
		{
			return $"f = {force}, t = {torque}\ndfv = {MatrixToString(d_force_vel)}\ndfa = {MatrixToString(d_force_ang)}\ndtv = {MatrixToString(d_torque_vel)}\ndta = {MatrixToString(d_torque_ang)}";
		}

		public void Transform(float3x3 m)
		{
			force = math.mul(m, force);
			torque = math.mul(m, torque);
			float3x3 inv = math.inverse(m);
			TransformDerivative(ref d_force_vel);
			TransformDerivative(ref d_force_ang);
			TransformDerivative(ref d_torque_vel);
			TransformDerivative(ref d_torque_ang);
			void TransformDerivative(ref float3x3 d)
			{
				d = math.mul(m, math.mul(d, inv));
			}
		}

		private static string MatrixToString(float3x3 matrix)
		{
			return $"\n{matrix.c0.x:00.0}, {matrix.c1.x:00.0}, {matrix.c2.x:00.0}\n" + $"{matrix.c0.y:00.0}, {matrix.c1.y:00.0}, {matrix.c2.y:00.0}\n" + $"{matrix.c0.z:00.0}, {matrix.c1.z:00.0}, {matrix.c2.z:00.0}\n";
		}
	}
}
