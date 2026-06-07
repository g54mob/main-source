using Unity.Collections;
using UnityEngine;

public class DebugMatrix : MonoBehaviour
{
	public static DebugMatrix inst;

	public Color32 Non_zero_color;

	public Color32 Zero_color;

	public Color32 Diff_add_color;

	public Color32 Diff_sub_color;

	public Color32 Same_color;

	public float Tex_scale;

	public bool Display_initial;

	public Vector2 Initial_stamp_tex_pos;

	private Texture2D initial_stamp_tex;

	private Color32[] initial_stamp_colors;

	public bool Display_compare;

	public Vector2 Compare_tex_pos;

	private Texture2D compare_tex;

	private Color32[] compare_colors;

	public static bool DisplayCompare => false;

	public static void ValueInserted()
	{
	}

	public void Awake()
	{
	}

	public static void CreateInitial(NativeArray<double> matx, int size)
	{
	}

	public static void CompareStampStep(NativeArray<double> oMatx, NativeArray<double> sMatx, int size)
	{
	}

	private void OnGUI()
	{
	}
}
