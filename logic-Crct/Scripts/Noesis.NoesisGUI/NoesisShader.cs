using System;
using UnityEngine;

public class NoesisShader : ScriptableObject
{
	public byte[] effect_bytecode;

	public IntPtr effect;

	public byte[] brush_path_bytecode;

	public IntPtr brush_path;

	public byte[] brush_path_aa_bytecode;

	public IntPtr brush_path_aa;

	public byte[] brush_sdf_bytecode;

	public IntPtr brush_sdf;

	public byte[] brush_opacity_bytecode;

	public IntPtr brush_opacity;
}
