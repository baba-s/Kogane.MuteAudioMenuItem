using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class MuteAudioMenuItem
    {
        private const string MENU_ITEM_NAME = "Kogane/Mute Audio";

        static MuteAudioMenuItem()
        {
            EditorApplication.delayCall += () => UpdateChecked();
        }

        [MenuItem( MENU_ITEM_NAME )]
        private static void Lock()
        {
            EditorUtility.audioMasterMute = !EditorUtility.audioMasterMute;

            foreach ( var editorWindow in Resources.FindObjectsOfTypeAll<EditorWindow>() )
            {
                editorWindow.Repaint();
            }

            UpdateChecked();
        }

        private static void UpdateChecked()
        {
            Menu.SetChecked( MENU_ITEM_NAME, EditorUtility.audioMasterMute );
        }
    }
}