using System;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    /// <summary>Utilities for <see cref="CameraSettings"/>.</summary>
    public static class CameraSettingsUtilities
    {
        /// <summary>Applies <paramref name="settings"/> to <paramref name="cam"/>.</summary>
        /// <param name="cam">Camera to update.</param>
        /// <param name="settings">Settings to apply.</param>
        public static void ApplySettings(this Camera cam, CameraSettings settings)
        {
            if (settings.frameSettings == null)
                throw new InvalidOperationException("'frameSettings' must not be null.");

            var add = cam.GetComponent<HDAdditionalCameraData>()
                ?? cam.gameObject.AddComponent<HDAdditionalCameraData>();

            add.SetPersistentFrameSettings(settings.frameSettings);
            // Frustum
            switch (settings.frustum.mode)
            {
                case CameraSettings.Frustum.Mode.UseProjectionMatrixField:
                    cam.projectionMatrix = settings.frustum.projectionMatrix;
                    break;
                case CameraSettings.Frustum.Mode.ComputeProjectionMatrix:
                    cam.nearClipPlane = settings.frustum.nearClipPlane;
                    cam.farClipPlane = settings.frustum.farClipPlane;
                    cam.fieldOfView = settings.frustum.fieldOfView;
                    cam.aspect = settings.frustum.aspect;
                    cam.projectionMatrix = settings.frustum.ComputeProjectionMatrix();
                    break;
            }
            // Culling
            cam.useOcclusionCulling = settings.culling.useOcclusionCulling;
            cam.cullingMask = settings.culling.cullingMask;
            // Buffer clearing
            add.clearColorMode = settings.bufferClearing.clearColorMode;
            add.backgroundColorHDR = settings.bufferClearing.backgroundColorHDR;
            add.clearDepth = settings.bufferClearing.clearDepth;
            // Volumes
            add.volumeLayerMask = settings.volumes.volumeLayerMask;
            add.volumeAnchorOverride = settings.volumes.volumeAnchorOverride;
            // Physical Parameters
            add.aperture = settings.physical.aperture;
            add.shutterSpeed = settings.physical.shutterSpeed;
            add.iso = settings.physical.iso;
            // HD Specific
            add.renderingPath = settings.renderingPath;
            add.flipYMode = settings.flipYMode;

            add.OnAfterDeserialize();
        }

        /// <summary>Applies <paramref name="settings"/> to <paramref name="cam"/>.</summary>
        /// <param name="cam">Camera to update.</param>
        /// <param name="settings">Settings to apply.</param>
        public static void ApplySettings(this Camera cam, CameraPositionSettings settings)
        {
            // Position
            switch (settings.mode)
            {
                case CameraPositionSettings.Mode.UseWorldToCameraMatrixField:
                    cam.worldToCameraMatrix = settings.worldToCameraMatrix;
                    break;
                case CameraPositionSettings.Mode.ComputeWorldToCameraMatrix:
                    cam.transform.position = settings.position;
                    cam.transform.rotation = settings.rotation;
                    cam.worldToCameraMatrix = settings.ComputeWorldToCameraMatrix();
                    break;
            }
        }
    }
}
