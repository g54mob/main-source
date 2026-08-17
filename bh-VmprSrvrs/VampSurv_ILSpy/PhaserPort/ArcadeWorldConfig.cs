using System;
using Cpp2ILInjected;
using Unity.Mathematics;

[Serializable]
public class ArcadeWorldConfig
{
	public int _fps;

	public bool _fixedStep;

	public double _timeScale;

	public float2 _gravity;

	public ArcadeBodyBounds _bounds;

	public CheckCollisionObject _checkCollision;

	public double _overlapBias;

	public double _tileBias;

	public bool _forceX;

	public bool _isPaused;

	public bool _debugShowRTrees;

	public bool _debugShowBody;

	public bool _debugShowStaticBody;

	public bool _debugShowVelocity;

	public int _debugBodyColor;

	public int _debugStaticBodyColor;

	public int _debugVelocityColor;

	public int _maxEntries;

	public bool _useTree;

	public bool _customUpdate;

	[NonSerialized]
	public const float _globalScale = 0.01f;

	public ArcadeWorldConfig()
	{
		//IL_00ea: Expected I, but got O
		_fps = 60;
		_timeScale = 1.0;
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		_gravity = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		_bounds = new ArcadeBodyBounds
		{
			x = 0f,
			width = 0f
		};
		_checkCollision = new CheckCollisionObject
		{
			_up = true
		};
		_debugShowBody = true;
		_overlapBias = 4.0;
		_tileBias = 16.0;
		_debugShowVelocity = true;
		_debugBodyColor = 16711935;
		_debugStaticBodyColor = 255;
		_debugVelocityColor = 65280;
		_maxEntries = 16;
		_useTree = true;
	}
}
