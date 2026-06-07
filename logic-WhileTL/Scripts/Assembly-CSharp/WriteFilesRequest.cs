using System.IO;
using Sony.PS4.SaveData;

public class WriteFilesRequest : FileOps.FileOperationRequest
{
	public byte[] data;

	public string fileName = "SaveName";

	public override void DoFileOperations(Mounting.MountPoint mp, FileOps.FileOperationResponse response)
	{
		WriteFilesResponse obj = response as WriteFilesResponse;
		string path = mp.PathName.Data + "/" + fileName;
		File.WriteAllBytes(path, data);
		FileInfo fileInfo = new FileInfo(path);
		obj.totalFileSizeWritten = fileInfo.Length;
		obj.lastWriteTime = fileInfo.LastWriteTime;
		obj.totalFileSizeWritten += fileInfo.Length;
	}
}
