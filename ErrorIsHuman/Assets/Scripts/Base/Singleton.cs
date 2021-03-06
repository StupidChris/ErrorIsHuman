﻿using UnityEngine;

namespace ErrorIsHuman.Base
{
    /// <summary>
    /// Immortal singleton base class
    /// </summary>
    /// <typeparam name="T">MonoBehaviour type</typeparam>
    [DisallowMultipleComponent]
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Instance
        /// <summary>
        /// Single immortal instance of this object
        /// </summary>
        public static T Instance { get; private set; }
        #endregion

        #region Virtual methods
        /// <summary>
        /// This is called from within Awake, you should override this instead of writing an Awake() method
        /// </summary>
        protected virtual void OnAwake() { }
        #endregion

        #region Functions
        private void Awake()
        {
            //Check for an existing instance
            if (Instance)
            {
                Destroy(this.gameObject);
                return;
            }

            //If none exist, create it
            Instance = this as T;
            DontDestroyOnLoad(this.gameObject);

            //Call children Awake()
            OnAwake();
        }
        #endregion
    }
}
