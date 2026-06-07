using System.IO;
using Sony.PS4.SaveData;

public class ReadFilesRequest : FileOps.FileOperationRequest
{
	public string fileName = "SaveName";

	public override void DoFileOperations(Mounting.MountPoint mp, FileOps.FileOperationResponse response)
	{
		ReadFilesResponse obj = response as ReadFilesResponse;
		string path = mp.PathName.Data + "/" + fileName;
		obj.data = File.ReadAllBytes(path);
	}
}
