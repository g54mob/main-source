using UnityEngine;

/* ============================================
   UNITY ROTATION METHODS - COMPLETE GUIDE
   ============================================ */

public class RotationMethodsExplained : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform visualRoot;

    /* ============================================
       METHOD 1: transform.rotation / localRotation
       ============================================
       
       PURPOSE: Direct transform manipulation (non-physics)
       WHEN: Static objects, visuals, UI, parented objects
       WHERE: Update(), LateUpdate()
       
       PHYSICS: ❌ BYPASSES physics system entirely
       
       CONSEQUENCES:
       - Teleports rotation instantly
       - Breaks physics interpolation
       - Can cause jitter with Rigidbody
       - Ignores collisions
       - Breaks joints/constraints
       
    */
    void Method1_TransformRotation()
    {
        // WORLD SPACE rotation
        transform.rotation = Quaternion.Euler(0, 90, 0);
        
        // LOCAL SPACE rotation (relative to parent)
        transform.localRotation = Quaternion.Euler(0, 90, 0);
        
        // ⚠️ NEVER USE WITH RIGIDBODY IN FIXEDUPDATE!
        // This creates physics/visual desync
    }

    /* ============================================
       METHOD 2: Rigidbody.MoveRotation()
       ============================================
       
       PURPOSE: Physics-safe rotation for kinematic movement
       WHEN: Physics objects that need precise rotation
       WHERE: FixedUpdate() ONLY
       
       PHYSICS: ✅ WORKS WITH physics system
       
       BENEFITS:
       - Respects physics timestep
       - Maintains interpolation (smooth visuals)
       - Triggers collision detection
       - Works with joints/constraints
       - Calculates proper velocity
       
       IDEAL FOR:
       - Player-controlled physics objects
       - Moving platforms
       - Kinematic rigidbodies
       - Arcade-style rotation (no torque needed)
       
    */
    void Method2_RigidbodyMoveRotation()
    {
        // Calculate target rotation
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
        
        // Apply in FixedUpdate
        rb.MoveRotation(targetRotation);
        
        // ✅ CORRECT: Physics-aware, smooth, collision-safe
    }

    /* ============================================
       METHOD 3: Rigidbody.AddTorque()
       ============================================
       
       PURPOSE: Physics-based rotation via forces
       WHEN: Realistic physics, space flight, cars
       WHERE: FixedUpdate() ONLY
       
       PHYSICS: ✅ FULL physics simulation
       
       BENEFITS:
       - Realistic angular acceleration
       - Works with mass/inertia
       - Affected by drag/friction
       - Can be overpowered by other forces
       
       DRAWBACKS:
       - Less predictable
       - Requires tuning
       - Can feel "floaty"
       
       IDEAL FOR:
       - Flight simulators
       - Space games
       - Realistic vehicles
       - Ragdolls
       
    */
    void Method3_RigidbodyAddTorque()
    {
        Vector3 torque = Vector3.up * 10f;
        
        // Different force modes
        rb.AddTorque(torque, ForceMode.Force);        // Continuous force
        rb.AddTorque(torque, ForceMode.Acceleration); // Ignores mass
        rb.AddTorque(torque, ForceMode.Impulse);      // Instant force
        rb.AddTorque(torque, ForceMode.VelocityChange); // Instant, ignores mass
        
        // ✅ CORRECT: Realistic physics rotation
    }

    /* ============================================
       METHOD 4: Rigidbody.rotation (Direct Set)
       ============================================
       
       PURPOSE: Direct rotation set (similar to transform)
       WHEN: Teleporting, respawning, initialization
       WHERE: Anywhere, but prefer FixedUpdate() for physics
       
       PHYSICS: ⚠️ PARTIALLY physics-aware
       
       BEHAVIOR:
       - Sets rotation directly
       - Resets angular velocity to zero
       - Can break interpolation
       - Better than transform but worse than MoveRotation
       
       USE CASES:
       - Respawning objects
       - Snapping to exact angles
       - Initialization
       
    */
    void Method4_RigidbodyRotationDirect()
    {
        rb.rotation = Quaternion.Euler(0, 90, 0);
        
        // ⚠️ OK but not ideal: Abrupt, resets velocity
        // Use MoveRotation() instead for smoother results
    }
}

/* ============================================
   PRACTICAL EXAMPLE: YOUR HELICOPTER
   ============================================ */

public class HeliRotationBestPractice : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform visualRoot;
    [SerializeField] float rotationSpeed = 180f;
    [SerializeField] float tiltAngleMax = 15f;
    [SerializeField] float maxSpeed = 20f;
    
    Vector2 moveInput;

    void FixedUpdate()
    {
        HandlePhysicsRotation();
    }

    void Update()
    {
        HandleVisualRotation();
    }

    /* ============================================
       PHYSICS ROTATION (Yaw)
       Uses: rb.MoveRotation()
       Why: Physics object needs smooth, collision-aware rotation
       ============================================ */
    void HandlePhysicsRotation()
    {
        if (moveInput.magnitude < 0.01f) return;

        // Calculate target yaw from input
        float targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;
        
        // Smooth interpolation
        float currentYaw = rb.rotation.eulerAngles.y;
        float newYaw = Mathf.MoveTowardsAngle(currentYaw, targetAngle, 
                                              rotationSpeed * Time.fixedDeltaTime);
        
        // Apply to RIGIDBODY via MoveRotation()
        Quaternion targetRotation = Quaternion.Euler(0f, newYaw, 0f);
        rb.MoveRotation(targetRotation);
        
        /* WHY rb.MoveRotation() HERE?
         * 
         * ✅ Rigidbody needs to know its rotation for:
         *    - Collision detection
         *    - Physics queries (raycasts relative to heli)
         *    - Force application direction
         *    - Smooth interpolation for rendering
         * 
         * ✅ MoveRotation() tells physics engine:
         *    "Move me to this rotation over this timestep"
         *    - Calculates angular velocity automatically
         *    - Maintains smooth 60fps visual even at 50 FixedUpdate
         *    - Triggers proper collision responses
         * 
         * ❌ If we used transform.rotation:
         *    - Physics wouldn't know heli rotated
         *    - Collisions would lag behind visuals
         *    - Interpolation would break (jittery)
         *    - Angular velocity would be zero
         */
    }

    /* ============================================
       VISUAL ROTATION (Pitch/Roll Tilt)
       Uses: transform.localRotation
       Why: Purely cosmetic, doesn't affect physics
       ============================================ */
    void HandleVisualRotation()
    {
        if (visualRoot == null) return;

        Vector3 localVel = rb.transform.InverseTransformDirection(rb.velocity);
        
        float pitchTilt = -localVel.z / maxSpeed * tiltAngleMax;
        float rollTilt = localVel.x / maxSpeed * tiltAngleMax;
        
        // Apply to CHILD VISUAL via transform.localRotation
        Quaternion targetTilt = Quaternion.Euler(pitchTilt, 0f, rollTilt);
        visualRoot.localRotation = Quaternion.Slerp(
            visualRoot.localRotation, 
            targetTilt, 
            10f * Time.deltaTime // Note: deltaTime, not fixedDeltaTime
        );
        
        /* WHY transform.localRotation HERE?
         * 
         * ✅ Tilt is VISUAL ONLY:
         *    - Doesn't affect collision bounds
         *    - Doesn't change physics behavior
         *    - Just makes heli "lean" for immersion
         * 
         * ✅ Using child transform:
         *    - Parent (rb) stays upright for physics
         *    - Child tilts for visuals
         *    - Best of both worlds!
         * 
         * ✅ In Update() not FixedUpdate():
         *    - Visual smoothness at display refresh rate
         *    - No need for physics timestep
         *    - More responsive feel
         * 
         * ❌ If we used rb.MoveRotation():
         *    - Physics would think heli is tilted
         *    - Collision detection would be wrong
         *    - Forces would apply in tilted directions
         *    - Arcade feel would be broken
         */
    }
}

/* ============================================
   DECISION TREE
   ============================================

   HAS RIGIDBODY?
   │
   ├─ NO → Use transform.rotation/localRotation freely
   │        (UI, static objects, visual effects)
   │
   └─ YES → Is this rotation affecting physics?
            │
            ├─ YES (yaw, facing, collision orientation)
            │   │
            │   ├─ Need arcade control? → rb.MoveRotation()
            │   └─ Need realistic physics? → rb.AddTorque()
            │
            └─ NO (visual tilt, wobble, cosmetic)
                │
                ├─ Has child visual? → child.transform.localRotation ✅
                └─ No child? → Create child, or use AddTorque carefully

   ============================================ */

/* ============================================
   COMMON MISTAKES
   ============================================

   ❌ MISTAKE 1: Using transform.rotation in FixedUpdate() with Rigidbody
      Problem: Breaks interpolation, causes jitter
      Fix: Use rb.MoveRotation()

   ❌ MISTAKE 2: Using rb.MoveRotation() for visual-only effects
      Problem: Affects physics when it shouldn't
      Fix: Use separate visual child with transform.localRotation

   ❌ MISTAKE 3: Mixing rotation methods on same object
      Problem: Fighting between systems
      Fix: Choose one authority (usually Rigidbody)

   ❌ MISTAKE 4: Using MoveRotation() in Update()
      Problem: Not synced with physics timestep
      Fix: Only use in FixedUpdate()

   ❌ MISTAKE 5: Forgetting interpolation setting
      Problem: Choppy visuals even with correct methods
      Fix: Set Rigidbody.interpolation = Interpolate

   ============================================ */

/* ============================================
   PERFORMANCE NOTES
   ============================================

   FASTEST → SLOWEST:
   1. transform.localRotation    (direct, no physics)
   2. rb.MoveRotation()           (kinematic, no forces)
   3. rb.rotation (direct set)    (resets velocity)
   4. rb.AddTorque()              (full simulation)

   For arcade helicopter:
   - Physics body: MoveRotation() (fast, precise)
   - Visual child: localRotation (fastest, cosmetic)
   - Perfect balance!

   ============================================ */