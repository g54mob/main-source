## transform.localEulerAngles Won't Go Past +90 deg on any axis

The issue you're experiencing is a classic Unity quaternion-to-Euler angle conversion problem known as **gimbal lock**.

When you do:
```csharp
blade.bladeObj.transform.localEulerAngles += this.collectiveInput * 10 * Time.deltaTime * blade.localRotateAxis;
```

Unity internally stores rotations as quaternions, not Euler angles. When you read `localEulerAngles`, Unity converts the quaternion to Euler angles, and when you write to it, Unity converts back. This conversion has limitations:

1. **Euler angles wrap and normalize** - Unity represents rotations in the range where X is clamped between -90° and +90°, and when X would exceed ±90°, Unity flips Y and Z by 180° to represent the same rotation differently.

2. **Non-cumulative** - Each frame you're reading the current converted Euler angles, adding to them, then setting them back. This doesn't accumulate rotation the way you expect.

### Solutions:

**Option 1: Track the angle separately (Recommended)**
```csharp
// Add a class field to track blade angles
Dictionary<Blade, float> bladeAngles = new Dictionary<Blade, float>();

// In HandleRotorsAndBlades:
foreach (var blade in this.BLADE)
{
	if (!bladeAngles.ContainsKey(blade))
		bladeAngles[blade] = 0f;

	if (blade.intakeInputType == Blade.IntakeInputType.head)
	{
		bladeAngles[blade] += this.collectiveInput * 10 * Time.deltaTime;
		blade.bladeObj.transform.localRotation = Quaternion.Euler(blade.localRotateAxis * bladeAngles[blade]);
	}
}
```

**Option 2: Use Rotate instead**
```csharp
blade.bladeObj.transform.Rotate(blade.localRotateAxis * this.collectiveInput * 10 * Time.deltaTime, Space.Self);
```

The first option gives you better control and allows you to clamp the angle if needed. The second is simpler but uses quaternion multiplication under the hood.







alright my next question is how do i clamp the rotation in a given axis
say for a given float, value = (value + vel * Time.deltaTime).clamp(0f, 10f);
is there a similar syntax way to achive for local rotation clamping for a given axis ?
where the axis shall be provided as arbitary vec3.


The issue is that my `rotateAndClamp` implementation still suffers from the same Euler angle gimbal lock problem. The `NormalizeAngle` and conversion back to Euler angles doesn't solve the fundamental issue.

**The real problem:** Unity's `eulerAngles` property always returns angles in a specific range, and when you cross certain thresholds, it flips representation.

Here's a **proper solution** that tracks the angle separately (which you really need):

**Update your Blade class:**

```csharp
[System.Serializable]
public class Blade
{
    public GameObject bladeObj = null;
    public int maxAngle = 30;
    public Vector3 localRotateAxis = new Vector3(1f, 0f, 0f);
    public IntakeInputType intakeInputType = IntakeInputType.head;
    
    // Track the actual angle (non-serialized, resets on play)
    [System.NonSerialized] public float currentAngle = 0f;

    public enum IntakeInputType
    {
        head, tail
    }
}
```

**Update HandleRotorsAndBlades:**

```csharp
void HandleRotorsAndBlades()
{
    foreach (var rotor in this.ROTOR)
        rotor.rotorObj.transform.localEulerAngles += (currRPSFactor * rotor.maxRPS * 360f * Time.deltaTime) * rotor.localRotateAxis;

    foreach (var blade in this.BLADE)
    {
        // Update the tracked angle with clamping
        blade.currentAngle = (blade.currentAngle + this.collectiveInput * 10 * Time.deltaTime * 10)
            .clamp(-blade.maxAngle, blade.maxAngle);
        
        // Apply the rotation
        blade.bladeObj.transform.localRotation = Quaternion.Euler(blade.localRotateAxis * blade.currentAngle);
    }
}
```

This approach:
- ✅ **No gimbal lock** - you're setting absolute rotation, not reading/modifying Euler angles
- ✅ **Clean syntax** - exactly the `.clamp()` style you wanted
- ✅ **Predictable behavior** - the angle is exactly what you expect
- ✅ **Works with arbitrary axes** - `blade.localRotateAxis` can be any vector

**Why the extension method failed:** You can't reliably extract, modify, and reapply Euler angles without hitting gimbal lock. Unity internally converts Quaternion → Euler → Quaternion, which loses information at certain angles.