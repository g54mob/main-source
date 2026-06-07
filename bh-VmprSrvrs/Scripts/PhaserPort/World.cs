using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Unity.Profiling;
using UnityEngine;

public class World : EventEmitter
{
	public PhaserScene _scene;

	public HashSet<Body> _bodies;

	private bool _iteratingOverBodies;

	private Stack<Body> _spareBodies;

	private HashSet<StaticBody> _staticBodies;

	private HashSet<BaseBody> _pendingAdd;

	private HashSet<BaseBody> _pendingDestroy;

	private ProcessQueue<Collider> _colliders;

	private Vector2 _gravity;

	public ArcadeBodyBounds _bounds;

	public CheckCollisionObject _checkCollision;

	private int _fps;

	private bool _fixedStep;

	private double _elapsed;

	private double _frameTime;

	private double _frameTimeMS;

	private int _stepsLastFrame;

	private double _timeScale;

	public float OVERLAP_BIAS;

	private float TILE_BIAS;

	private bool _forceX;

	private bool _isPaused;

	private int _total;

	public ArcadeWorldDefaults _defaults;

	private int _maxEntries;

	public bool _useTree;

	private List<Group> _groupsWithRTrees;

	private Dictionary<Group, RBush> _groupRTrees;

	public RBush _staticTree;

	private ArcadeWorldConfig _config;

	private static readonly ProfilerMarker _markerEnableBody;

	private static readonly ProfilerMarker MarkerAdd;

	private static readonly ProfilerMarker s_updateMarker;

	private static readonly ProfilerMarker s_preUpdateMarker;

	private static readonly ProfilerMarker s_collidersMarker;

	private static readonly ProfilerMarker s_stepMarker;

	private static readonly ProfilerMarker s_postUpdateMarker;

	private static readonly ProfilerMarker s_drawDebugMarker;

	private static readonly ProfilerMarker s_bodyDestructionMarker;

	private static readonly ProfilerMarker s_separateMarker;

	private static readonly ProfilerMarker s_separateCircleMarker;

	private static readonly ProfilerMarker s_separateCircleSqrRtMarker;

	private static readonly ProfilerMarker s_intersectsMarker;

	private PhaserTile[] _tileCache;

	private static readonly ProfilerMarker s_spriteVsTilemapMarker;

	private static readonly ProfilerMarker s_spriteVsTilemapFastMarker;

	private static readonly ProfilerMarker s_spriteVsTilemapCallbacksMarker;

	private static readonly ProfilerMarker s_separateTileMarker;

	public World(PhaserScene scene, ArcadeWorldConfig config)
	{
	}

	public void enable(ArcadeColliderType obj, PhysicsType bodyType = PhysicsType.DYNAMIC_BODY)
	{
	}

	public PhaserGameObject enableBody(PhaserGameObject obj, PhysicsType bodyType = PhysicsType.DYNAMIC_BODY)
	{
		return null;
	}

	public BaseBody add(BaseBody body)
	{
		return null;
	}

	private void disable(ArcadeColliderType obj)
	{
	}

	public void disableBody(BaseBody body)
	{
	}

	private void remove(BaseBody body)
	{
	}

	public World setBounds(float x, float y, float width, float height, bool? checkLeft = null, bool checkRight = true, bool checkUp = true, bool checkDown = true)
	{
		return null;
	}

	public World setBoundsCollision(bool left = true, bool right = true, bool up = true, bool down = true)
	{
		return null;
	}

	public World pause()
	{
		return null;
	}

	public World resume()
	{
		return null;
	}

	public Collider addCollider(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext)
	{
		return null;
	}

	public Collider addOverlap(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext)
	{
		return null;
	}

	public Collider addColliderDirect(Collider collider)
	{
		return null;
	}

	public World removeCollider(Collider collider)
	{
		return null;
	}

	public World insertColliderDirect(Collider collider, int position)
	{
		return null;
	}

	public void setFPS(int frameRate)
	{
	}

	public void update()
	{
	}

	public void step(float delta, bool runBodyStep = true)
	{
	}

	private void UpdateGroups()
	{
	}

	public void postUpdate()
	{
	}

	public void updateMotion(Body body, float delta)
	{
	}

	public void computeAngularVelocity(Body body, float delta)
	{
	}

	public void computeVelocity(Body body, float delta)
	{
	}

	private bool separate(BaseBody body1, BaseBody body2, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly, bool intersects = false)
	{
		return false;
	}

	public bool separateCircle(BaseBody body1, BaseBody body2, bool overlapOnly, float bias = 0f)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool intersects(BaseBody body1, BaseBody body2)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool circleBodyIntersects(BaseBody circle, BaseBody body)
	{
		return false;
	}

	public bool overlap(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		return false;
	}

	public bool collide(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		return false;
	}

	public bool collideObjects(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	private bool collideHandler(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	private bool collideSpriteVsSprite(PhaserGameObject sprite1, PhaserGameObject sprite2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	private bool collideSpriteVsGroup(PhaserGameObject sprite, PhysicsGroup group, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	private bool collideGroupVsTilemapLayer(Group group, PhaserTilemap tilemapLayer, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	public bool collideSpriteVsTilemapLayer(PhaserGameObject sprite, PhaserTilemap tilemap, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	public void collideSpriteVsTilemapLayerFast(PhaserGameObject sprite, PhaserTilemap tilemap, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
	}

	[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
	private bool collideSpriteVsTilesHandler(PhaserGameObject sprite, BoundsInt bounds, PhaserTile[] tiles, int tilesCount, PhaserTilemap tilemapLayer, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly, bool isLayer)
	{
		return false;
	}

	private bool SeparateTile(int i, Body body, PhaserTile tile, ref ArcadeRect tileWorldRect, PhaserTilemap tilemapLayer, float tileBias, bool isLayer)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool TileIntersectsBody(ref ArcadeRect tileWorldRect, BaseBody body)
	{
		return false;
	}

	private bool collideGroupVsGroup(PhysicsGroup group1, PhysicsGroup group2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext, bool overlapOnly)
	{
		return false;
	}

	public void wrap(ArcadeColliderType obj, float padding = 0f)
	{
	}

	public void wrapArray(IEnumerable<ArcadeColliderType> objs, float padding = 0f)
	{
	}

	public void wrapObject(ArcadeColliderType generalObj, float padding = 0f)
	{
	}

	private float Wrap(float v, float left, float right)
	{
		return 0f;
	}

	public RBush GetTree(Group group)
	{
		return null;
	}

	public RBush addGroupTree(Group group)
	{
		return null;
	}

	public void addSubsetGroupTree(Group group, Group parentGroup)
	{
	}

	public void destroyBody(BaseBody body)
	{
	}

	private void shutdown()
	{
	}

	public void destroy()
	{
	}
}
