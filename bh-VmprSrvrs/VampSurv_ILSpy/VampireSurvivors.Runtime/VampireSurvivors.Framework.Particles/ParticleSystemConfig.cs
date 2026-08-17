using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Particles;

[Serializable]
public class ParticleSystemConfig
{
	public enum ScaleMode
	{
		Initial,
		Lifetime
	}

	public ParticleSystem.MinMaxCurve _x;

	public ParticleSystem.MinMaxCurve _y;

	public List<string> _frame;

	public int _fps;

	public ParticleSystem.MinMaxCurve _angle;

	public int _angleSteps;

	public ParticleSystem.MinMaxCurve? _speed;

	public ParticleSystem.MinMaxCurve? _speedX;

	public ParticleSystem.MinMaxCurve? _speedY;

	public int? _quantity;

	public float? _frequency;

	public ParticleSystem.MinMaxCurve _rotate;

	public ParticleSystem.MinMaxCurve _lifespan;

	public ParticleSystem.MinMaxCurve? _alpha;

	public Easing _alphaEase;

	public ParticleSystem.MinMaxCurve? _scale;

	public ParticleSystem.MinMaxCurve? _scaleX;

	public ParticleSystem.MinMaxCurve? _scaleY;

	public ScaleMode? _scaleMode;

	public Easing _scaleEase;

	public ParticleSystem.MinMaxCurve _gravity;

	public uint? _tint;

	public uint[] _tintRandom;

	public bool _on;

	public BlendMode? _blendMode;

	public ParticleSystem.MinMaxCurve? _bounce;

	public Rect? _bounds;

	public Bounds? _boundsWorld;

	public bool? _collideTop;

	public bool? _collideBottom;

	public bool? _collideLeft;

	public bool? _collideRight;

	public EmitZone _emitZone;

	public ParticleSystemSimulationSpace? _simulationSpace;

	public bool _circleCollision;

	public float _circleCollisionRadius;

	private readonly string _003CTexture_003Ek__BackingField;

	public string Texture => _003CTexture_003Ek__BackingField;

	public unsafe ParticleSystemConfig(string texture)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0287: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_003f: Expected O, but got Ref
		//IL_0059: Expected native int or pointer, but got O
		//IL_0070: Expected O, but got I
		//IL_00ac: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_00e3: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_02aa: Expected O, but got I
		//IL_0145: Expected O, but got Ref
		//IL_016a: Expected native int or pointer, but got O
		//IL_02e1: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_01dc: Expected O, but got I4
		//IL_0205: Expected O, but got I
		//IL_0318: Expected O, but got I
		//IL_035e: Expected O, but got I
		//IL_037c: Expected O, but got I
		//IL_0394: Expected O, but got I
		//IL_03a6: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-1]");
		_angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_quantity = (int?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_frequency = (float?)(object)0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_rotate = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		_lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-79]");
		_alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-69]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 31));
		_alphaEase = Easing.Linear;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2F]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-51]");
		_scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-41]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_scaleMode = (ScaleMode?)(object)0;
		_scaleEase = Easing.Linear;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_blendMode = (BlendMode?)(object)0;
		_on = true;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
		_bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-9]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_collideTop = (bool?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		_collideRight = (bool?)(object)0;
		string text;
		if (texture != null)
		{
			bool flag = texture._stringLength > 0;
			text = texture;
			if (flag)
			{
				goto IL_0337;
			}
		}
		text = "vfx";
		goto IL_0337;
		IL_0337:
		_003CTexture_003Ek__BackingField = text;
	}
}
