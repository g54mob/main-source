using UnityEngine;

public class fts
{
	public static bool IsZero(double d)
	{
		return false;
	}

	public static int SolveQuadric(double c0, double c1, double c2, out double s0, out double s1)
	{
		s0 = default(double);
		s1 = default(double);
		return 0;
	}

	public static int SolveCubic(double c0, double c1, double c2, double c3, out double s0, out double s1, out double s2)
	{
		s0 = default(double);
		s1 = default(double);
		s2 = default(double);
		return 0;
	}

	public static int SolveQuartic(double c0, double c1, double c2, double c3, double c4, out double s0, out double s1, out double s2, out double s3)
	{
		s0 = default(double);
		s1 = default(double);
		s2 = default(double);
		s3 = default(double);
		return 0;
	}

	public static float ballistic_range(float speed, float gravity, float initial_height)
	{
		return 0f;
	}

	public static int solve_ballistic_arc(Vector3 proj_pos, float proj_speed, Vector3 target, float gravity, out Vector3 s0, out Vector3 s1)
	{
		s0 = default(Vector3);
		s1 = default(Vector3);
		return 0;
	}

	public static int solve_ballistic_arc(Vector3 proj_pos, float proj_speed, Vector3 target_pos, Vector3 target_velocity, float gravity, out Vector3 s0, out Vector3 s1)
	{
		s0 = default(Vector3);
		s1 = default(Vector3);
		return 0;
	}

	public static bool solve_ballistic_arc_lateral(Vector3 proj_pos, float lateral_speed, Vector3 target_pos, float max_height, out Vector3 fire_velocity, out float gravity, out float time)
	{
		fire_velocity = default(Vector3);
		gravity = default(float);
		time = default(float);
		return false;
	}

	public static bool solve_ballistic_arc_lateral(Vector3 proj_pos, float lateral_speed, Vector3 target, Vector3 target_velocity, float max_height_offset, out Vector3 fire_velocity, out float gravity, out Vector3 impact_point)
	{
		fire_velocity = default(Vector3);
		gravity = default(float);
		impact_point = default(Vector3);
		return false;
	}
}
