using System;
using System.Text;
using Unity.Collections;
using Unity.Entities;

public struct BlobByteArray
{
	public BlobArray<byte> Data;

	public unsafe static BlobAssetReference<BlobByteArray> CreateFromString(string data)
	{
		int byteCount = Encoding.UTF8.GetByteCount(data);
		BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, byteCount + 1024);
		BlobBuilderArray<byte> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobByteArray>().Data, byteCount);
		Span<byte> bytes = new Span<byte>(blobBuilderArray.GetUnsafePtr(), blobBuilderArray.Length);
		Encoding.UTF8.GetBytes(data, bytes);
		return blobBuilder.CreateBlobAssetReference<BlobByteArray>(Allocator.Persistent);
	}

	public unsafe static string DataToString(BlobAssetReference<BlobByteArray> blob)
	{
		byte* unsafePtr = (byte*)blob.Value.Data.GetUnsafePtr();
		int length = blob.Value.Data.Length;
		return Encoding.UTF8.GetString(unsafePtr, length);
	}
}
