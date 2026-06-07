using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Profiling;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	[BurstCompile]
	public class ProceduralWindowScript : TrapezoidMeshModifierScript
	{
		private static class Profile
		{
			public static readonly ProfilerMarker Split = new ProfilerMarker("MeshModifierBaseScript.Apply.Split");

			public static readonly ProfilerMarker Transform = new ProfilerMarker("MeshModifierBaseScript.Apply.Transform");

			public static readonly ProfilerMarker AddTransparency = new ProfilerMarker("MeshModifierBaseScript.Apply.AddTransparency");

			public static readonly ProfilerMarker Emit = new ProfilerMarker("MeshModifierBaseScript.Apply.Emit");
		}

		public override bool ModifiesColliders => Data.HideGlass;

		public new ProceduralWindowData Data { get; private set; }

		public void Initialize(ProceduralWindowData data)
		{
			Data = data;
			base.OnCreateRenderer += delegate(int id, ProceduralPartMeshRenderer r)
			{
				if (id == 0)
				{
					r.EnableTransparency = true;
				}
			};
			Initialize((MeshModifierBaseData)data);
		}

		protected override Manifold<Vertex> Apply(MeshModifyContext ctx, Allocator allocator, ref Manifold<Vertex> colliderOut)
		{
			if (Data.HideGlass)
			{
				colliderOut = ctx.TargetCollider?.Subtract(allocator, ctx.SourceInTargetSpace);
				return ctx.Target.Subtract(allocator, ctx.SourceInTargetSpace);
			}
			var (manifold, result) = ctx.Target.Split(Allocator.Temp, allocator, ctx.SourceInTargetSpace);
			using Manifold<Vertex> manifold2 = manifold;
			using Manifold<Vertex> manifold3 = manifold2.Transform(Allocator.Temp, ctx.ModifierFromTarget);
			ulong num = 18446744073709551583uL;
			TransparencyScript modifier = ctx.TargetPart.GetModifier<TransparencyScript>();
			if (modifier != null)
			{
				num &= modifier.LevelVisibilityMask;
			}
			ctx.EmitLocalMeshPart(manifold3, 0, num);
			return result;
		}
	}
}
