using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

// AsPerUnusual on GitHub

// ## this script assumes only integers separated by periods: #.#.#  It currently will not handle letters mixed in ##

public static class CreateVersionChangeMenu
{
  //place in Assets/Editor folder
  const string _BaseMenuString = "Tools/Version Increase/"; // replace with the menu name or existing menu you prefer, this adds a new menu "Tools" with one item "Version Increase"
																// menu items under "Version Increase" are set above each function by adding to this base string

  [MenuItem( _BaseMenuString + "Super Small Changes" )] // things like version change to get into an app store when certificate expired but no code change
  static void ChangeWasSuperSmall() {

	List<string> currentVersionList = GetVersionNumber();
	
    if ( CheckExpectedNumbering( currentVersionList ) ) {
    
    	if ( currentVersionList.Count == 4 ) {
    	
    		int tempDigit = int.Parse( currentVersionList[ 3 ] );
    	
    		tempDigit += 1;
    		
    		currentVersionList[ 3 ] = tempDigit.ToString();
    	
    	} else {
    	
    		if ( currentVersionList.Count < 3 ){
    			//right now effectively skip if the string is shorter than 3 items, reserved for later if short version strings are seen to be a problem, Unity default on a new project is 0.1.0
    		} else {
    			currentVersionList.Add( "1" );
    		}
    	}
    	
    	string versionRebuilt = string.Join( '.', currentVersionList );
    	
    	UnityEditor.PlayerSettings.bundleVersion = versionRebuilt;
    	Debug.Log( $"Version Increase SuperSmall Called: { versionRebuilt }");
    	
    	EditorApplication.ExecuteMenuItem( "File/Save Project" ); //to avoid having to remember to use the menu before quitting
    }
  }

  [MenuItem( _BaseMenuString + "Fixes - Adjustments" )]
  static void ChangeWasAdjustment() {

	List<string> currentVersionList = GetVersionNumber();
	
    if ( CheckExpectedNumbering( GetVersionNumber() ) ) {
    
    	if ( currentVersionList.Count >= 3 ) {
    	
    		int tempDigit = int.Parse( currentVersionList[ 2 ] );
    	
    		tempDigit += 1;
    		
    		currentVersionList[ 2 ] = tempDigit.ToString();
    		
    		if ( currentVersionList.Count == 4 ) currentVersionList.RemoveAt( 3 ); //remove super small version for this new update
    	} else {
    	
    		currentVersionList.Add( "1" );
    	}
    	
    	string versionRebuilt = string.Join( '.', currentVersionList );
    	
    	UnityEditor.PlayerSettings.bundleVersion = versionRebuilt;
    	Debug.Log( $"Version Increase Fixes - Adjustments Called: { versionRebuilt }");
    	
    	EditorApplication.ExecuteMenuItem( "File/Save Project" );
    }
  }

  [MenuItem( _BaseMenuString + "Feature Level Changes" )]
  static void ChangeWasFeatureLevel() {

	
	List<string> currentVersionList = GetVersionNumber();
	
    if ( CheckExpectedNumbering( GetVersionNumber() ) ) {
    
    	if ( currentVersionList.Count >= 2 ) {
    	
    		int tempDigit = int.Parse( currentVersionList[ 1 ] );
    	
    		tempDigit += 1;
    		
    		currentVersionList[ 1 ] = tempDigit.ToString();
    	
    		if ( currentVersionList.Count == 4 ) currentVersionList.RemoveAt( 3 ); //remove super small version for this new update
    		currentVersionList[ 2 ] = "0";
    	}
    
    	string versionRebuilt = string.Join( '.', currentVersionList );
    	
    	UnityEditor.PlayerSettings.bundleVersion = versionRebuilt;
    	Debug.Log( $"Version Increase Feature Called: { versionRebuilt }");
    	
    	EditorApplication.ExecuteMenuItem( "File/Save Project" );
    }
  }

  [MenuItem( _BaseMenuString + "Full Version Level Changes" )]
  static void NewFullVersion() {
  
  	List<string> currentVersionList = GetVersionNumber();
  	
    if ( CheckExpectedNumbering( GetVersionNumber() ) ) {
    	
    	int tempDigit = int.Parse( currentVersionList[ 0 ] );
    	
    	tempDigit += 1;
    		
    	currentVersionList[ 0 ] = tempDigit.ToString();
    	
    	if ( currentVersionList.Count == 4 ) currentVersionList.RemoveAt( 3 ); //remove super small version for this new update
    	currentVersionList[ 2 ] = "0";
    	currentVersionList[ 1 ] = "0";
    	
    	string versionRebuilt = string.Join( '.', currentVersionList );
    	
    	UnityEditor.PlayerSettings.bundleVersion = versionRebuilt;
    	Debug.Log( $"Version Increase Full Called: { versionRebuilt }");
    	
    	EditorApplication.ExecuteMenuItem( "File/Save Project" );
    }
  }
  
  static bool CheckExpectedNumbering( List<string> testArray ) {
    
    if ( testArray.Count <= 1 ) {
      
      //Debug.LogError( "Problem with Version number format while trying to change it. #.#.# format expected" );
      return !( EditorUtility.DisplayDialog( "The existing Version string does not seem to be in the right format.", "It should resemble #.#.#", "Ok" ) );
    } else {
      return true;
    }
  }
  
  static List<string> GetVersionNumber() {
    
 	string versionString = UnityEditor.PlayerSettings.bundleVersion;
	List<string> versionList = versionString.Split( '.' ).ToList(); //single quotes for char, char.Parse for double quotes

	return versionList;
  }

}