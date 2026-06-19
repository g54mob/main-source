using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Gpu : ISentryJsonSerializable, ICloneable<Gpu>, IUpdatable<Gpu>, IUpdatable
	{
		public const string Type = "gpu";

		public string? Name { get; set; }

		public int? Id { get; set; }

		public string? VendorId { get; set; }

		public string? VendorName { get; set; }

		public int? MemorySize { get; set; }

		public string? ApiType { get; set; }

		public bool? MultiThreadedRendering { get; set; }

		public string? Version { get; set; }

		public string? NpotSupport { get; set; }

		public int? MaxTextureSize { get; set; }

		public string? GraphicsShaderLevel { get; set; }

		public bool? SupportsDrawCallInstancing { get; set; }

		public bool? SupportsRayTracing { get; set; }

		public bool? SupportsComputeShaders { get; set; }

		public bool? SupportsGeometryShaders { get; set; }

		internal Gpu Clone()
		{
			return ((ICloneable<Gpu>)this).Clone();
		}

		Gpu ICloneable<Gpu>.Clone()
		{
			return new Gpu
			{
				Name = Name,
				Id = Id,
				VendorId = VendorId,
				VendorName = VendorName,
				MemorySize = MemorySize,
				ApiType = ApiType,
				MultiThreadedRendering = MultiThreadedRendering,
				Version = Version,
				NpotSupport = NpotSupport,
				MaxTextureSize = MaxTextureSize,
				GraphicsShaderLevel = GraphicsShaderLevel,
				SupportsDrawCallInstancing = SupportsDrawCallInstancing,
				SupportsRayTracing = SupportsRayTracing,
				SupportsComputeShaders = SupportsComputeShaders,
				SupportsGeometryShaders = SupportsGeometryShaders
			};
		}

		internal void UpdateFrom(Gpu source)
		{
			((IUpdatable<Gpu>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is Gpu source2)
			{
				((IUpdatable<Gpu>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<Gpu>.UpdateFrom(Gpu source)
		{
			if (Name == null)
			{
				string text = (Name = source.Name);
			}
			if (!Id.HasValue)
			{
				int? num = (Id = source.Id);
			}
			if (VendorId == null)
			{
				string text = (VendorId = source.VendorId);
			}
			if (VendorName == null)
			{
				string text = (VendorName = source.VendorName);
			}
			if (!MemorySize.HasValue)
			{
				int? num = (MemorySize = source.MemorySize);
			}
			if (ApiType == null)
			{
				string text = (ApiType = source.ApiType);
			}
			if (!MultiThreadedRendering.HasValue)
			{
				bool? flag = (MultiThreadedRendering = source.MultiThreadedRendering);
			}
			if (Version == null)
			{
				string text = (Version = source.Version);
			}
			if (NpotSupport == null)
			{
				string text = (NpotSupport = source.NpotSupport);
			}
			if (!MaxTextureSize.HasValue)
			{
				int? num = (MaxTextureSize = source.MaxTextureSize);
			}
			if (GraphicsShaderLevel == null)
			{
				string text = (GraphicsShaderLevel = source.GraphicsShaderLevel);
			}
			if (!SupportsDrawCallInstancing.HasValue)
			{
				bool? flag = (SupportsDrawCallInstancing = source.SupportsDrawCallInstancing);
			}
			if (!SupportsRayTracing.HasValue)
			{
				bool? flag = (SupportsRayTracing = source.SupportsRayTracing);
			}
			if (!SupportsComputeShaders.HasValue)
			{
				bool? flag = (SupportsComputeShaders = source.SupportsComputeShaders);
			}
			if (!SupportsGeometryShaders.HasValue)
			{
				bool? flag = (SupportsGeometryShaders = source.SupportsGeometryShaders);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "gpu");
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteNumberIfNotNull("id", Id);
			writer.WriteStringIfNotWhiteSpace("vendor_id", VendorId);
			writer.WriteStringIfNotWhiteSpace("vendor_name", VendorName);
			writer.WriteNumberIfNotNull("memory_size", MemorySize);
			writer.WriteStringIfNotWhiteSpace("api_type", ApiType);
			writer.WriteBooleanIfNotNull("multi_threaded_rendering", MultiThreadedRendering);
			writer.WriteStringIfNotWhiteSpace("version", Version);
			writer.WriteStringIfNotWhiteSpace("npot_support", NpotSupport);
			writer.WriteNumberIfNotNull("max_texture_size", MaxTextureSize);
			writer.WriteStringIfNotWhiteSpace("graphics_shader_level", GraphicsShaderLevel);
			writer.WriteBooleanIfNotNull("supports_draw_call_instancing", SupportsDrawCallInstancing);
			writer.WriteBooleanIfNotNull("supports_ray_tracing", SupportsRayTracing);
			writer.WriteBooleanIfNotNull("supports_compute_shaders", SupportsComputeShaders);
			writer.WriteBooleanIfNotNull("supports_geometry_shaders", SupportsGeometryShaders);
			writer.WriteEndObject();
		}

		public static Gpu FromJson(JsonElement json)
		{
			string name = json.GetPropertyOrNull("name")?.GetString();
			int? id = json.GetPropertyOrNull("id")?.GetInt32();
			string vendorId = json.GetPropertyOrNull("vendor_id")?.GetString();
			string vendorName = json.GetPropertyOrNull("vendor_name")?.GetString();
			int? memorySize = json.GetPropertyOrNull("memory_size")?.GetInt32();
			string apiType = json.GetPropertyOrNull("api_type")?.GetString();
			bool? multiThreadedRendering = json.GetPropertyOrNull("multi_threaded_rendering")?.GetBoolean();
			string version = json.GetPropertyOrNull("version")?.GetString();
			string npotSupport = json.GetPropertyOrNull("npot_support")?.GetString();
			int? maxTextureSize = json.GetPropertyOrNull("max_texture_size")?.GetInt32();
			string graphicsShaderLevel = json.GetPropertyOrNull("graphics_shader_level")?.GetString();
			bool? supportsDrawCallInstancing = json.GetPropertyOrNull("supports_draw_call_instancing")?.GetBoolean();
			bool? supportsRayTracing = json.GetPropertyOrNull("supports_ray_tracing")?.GetBoolean();
			bool? supportsComputeShaders = json.GetPropertyOrNull("supports_compute_shaders")?.GetBoolean();
			bool? supportsGeometryShaders = json.GetPropertyOrNull("supports_geometry_shaders")?.GetBoolean();
			return new Gpu
			{
				Name = name,
				Id = id,
				VendorId = vendorId,
				VendorName = vendorName,
				MemorySize = memorySize,
				ApiType = apiType,
				MultiThreadedRendering = multiThreadedRendering,
				Version = version,
				NpotSupport = npotSupport,
				MaxTextureSize = maxTextureSize,
				GraphicsShaderLevel = graphicsShaderLevel,
				SupportsDrawCallInstancing = supportsDrawCallInstancing,
				SupportsRayTracing = supportsRayTracing,
				SupportsComputeShaders = supportsComputeShaders,
				SupportsGeometryShaders = supportsGeometryShaders
			};
		}
	}
}
