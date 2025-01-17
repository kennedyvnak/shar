using NFHGame.Serialization;
using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace NFHGameEditor.Serialization {
    [ScriptedImporter(1, "save")]
    public class GameDataImporter : ScriptedImporter {
        public override void OnImportAsset(AssetImportContext ctx) {
            string json = NFHGame.Serialization.Handlers.DataHandler.EncryptDecrypt(File.ReadAllText(ctx.assetPath));
            GameDataAsset gameDataAsset = ScriptableObject.CreateInstance<GameDataAsset>();
            gameDataAsset.LoadFromJson(json);
            gameDataAsset.name = Path.GetFileName(ctx.assetPath);
            ctx.AddObjectToAsset("main obj", gameDataAsset);
            ctx.SetMainObject(gameDataAsset);
        }
    }
}