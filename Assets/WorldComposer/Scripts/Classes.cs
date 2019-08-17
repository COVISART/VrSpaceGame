using System;

#if UNITY_EDITOR
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEditor;

[Serializable]
public class area_class
{
	public bool active;
	public bool foldout;
	public Rect area;
	public Rect area_old;
	public Rect area_max;
	public Vector2 center;
	public Vector2 image_offset;
	public Vector3 rotation;
	public bool rotation_active;
	public bool link_start;
	public bool link_end;
	public float resolution;
	public float custom_resolution;
	public Vector2 step;
	public Vector2 step_old;
	public Vector2 conversion_step;
	public resolution_mode_enum resolution_mode;
	public string resolution_mode_text;
	public string resolution_tooltip_text;
	public int tree_resolution;
	public int object_resolution;
	public int colormap_resolution;
	public bool tree_resolution_active;
	public bool object_resolution_active;

	public area_class()
	{
		active = true;
		link_start = true;
		link_end = true;
		resolution_mode = resolution_mode_enum.Automatic;
		tree_resolution = 128;
		object_resolution = 32;
		colormap_resolution = 2048;
	}

	public void max()
	{
		area = area_max;
	}

	public Rect round_area_to_step(Rect area1)
	{
		area1.xMin = Mathf.Round(area1.xMin / step.x) * step.x;
		area1.xMax = Mathf.Round(area1.xMax / step.x) * step.x;
		area1.yMin = Mathf.Round(area1.yMin / step.y) * step.y;
		area1.yMax = Mathf.Round(area1.yMax / step.y) * step.y;
		return area1;
	}

	public void set_resolution_mode_text()
	{
		if (area == area_max)
		{
			resolution_mode_text = "M";
			resolution_tooltip_text = "Maximum Area Selected";
		}
		else
		{
			resolution_mode_text = "C";
			resolution_tooltip_text = "Custum Area Selected";
		}
		if (resolution_mode == resolution_mode_enum.Automatic)
		{
			resolution_mode_text += "-> A";
			resolution_tooltip_text += "\n\nStep Mode is on Automatic";
		}
		else if (resolution_mode == resolution_mode_enum.Heightmap)
		{
			resolution_mode_text += "-> H";
			resolution_tooltip_text += "\n\nStep Mode is on Heightmap";
		}
		else if (resolution_mode == resolution_mode_enum.Splatmap)
		{
			resolution_mode_text += "-> S";
			resolution_tooltip_text += "\n\nStep Mode is on Splatmap";
		}
		else if (resolution_mode == resolution_mode_enum.Detailmap)
		{
			resolution_mode_text += "-> D";
			resolution_tooltip_text += "\n\nStep Mode is on Detailmap";
		}
		else if (resolution_mode == resolution_mode_enum.Tree)
		{
			resolution_mode_text += "-> T";
			resolution_tooltip_text += "\n\nStep Mode is on Tree";
		}
		else if (resolution_mode == resolution_mode_enum.Object)
		{
			resolution_mode_text += "-> O";
			resolution_tooltip_text += "\n\nStep Mode is on Object";
		}
		else if (resolution_mode == resolution_mode_enum.Units)
		{
			resolution_mode_text += "-> U";
			resolution_tooltip_text += "\n\nStep Mode is on Units";
		}
		else if (resolution_mode == resolution_mode_enum.Custom)
		{
			resolution_mode_text += "-> C";
			resolution_tooltip_text += "\n\nStep Mode is on Custom";
		}
	}
}

[Serializable]
public class auto_search_class
{
	public string path_full;
	public string path;
	public bool foldout;
	public bool custom;
	public int digits;
	public string format;
	public string filename;
	public string fullname;
	public string name;
	public string extension;
	public int start_x;
	public int start_y;
	public int start_n;
	public int count_x;
	public int count_y;
	public bool display;
	public int select_index;
	public Rect menu_rect;
	public string output_format;

	public auto_search_class()
	{
		path_full = string.Empty;
		path = string.Empty;
		digits = 1;
		format = "%n";
		filename = "tile";
		extension = ".raw";
		start_n = 1;
		count_x = 1;
		count_y = 1;
		select_index = -1;
		output_format = "1";
	}

	public void set_output_format()
	{
		if (digits < 1)
		{
			digits = 1;
		}
		string text = new string("0"[0], digits);
		output_format = format.Replace("%x", start_x.ToString(text));
		output_format = output_format.Replace("%y", start_y.ToString(text));
		output_format = output_format.Replace("%n", start_n.ToString(text));
	}

	public bool strip_file()
	{
		string text = new string("0"[0], digits);
		string text2 = format.Replace("%x", start_x.ToString(text));
		text2 = text2.Replace("%y", start_y.ToString(text));
		text2 = text2.Replace("%n", start_n.ToString(text));

        if (path_full.Length == 0) return false;
		
		path = Path.GetDirectoryName(path_full);
		filename = Path.GetFileNameWithoutExtension(path_full);
		filename = filename.Replace(text2, string.Empty);
		extension = Path.GetExtension(path_full);

        return true;
	}

	public void strip_name()
	{
		string text = new string("0"[0], digits);
		string text2 = format.Replace("%x", start_x.ToString(text));
		text2 = text2.Replace("%y", start_y.ToString(text));
		text2 = text2.Replace("%n", start_n.ToString(text));
		name = fullname;

        if (text2.Length > 0)
		{
			name = name.Replace(text2, string.Empty);
		}
	}

	public string get_file(int count_x, int count_y, int count_n)
	{
		string text = new string("0"[0], digits);
		string text2 = format.Replace("%x", (count_x + start_x).ToString(text));
		text2 = text2.Replace("%y", (count_y + start_y).ToString(text));
		text2 = text2.Replace("%n", (count_n + start_n).ToString(text));
		return path + "/" + filename + text2 + extension;
	}

	public string get_name(int count_x, int count_y, int count_n)
	{
		string text = new string("0"[0], digits);
		string text2 = format.Replace("%x", (count_x + start_x).ToString(text));
		text2 = text2.Replace("%y", (count_y + start_y).ToString(text));
		text2 = text2.Replace("%n", (count_n + start_n).ToString(text));
		return name + text2;
	}
}

[Serializable]
public class BitmapData
{
	public int height;
	public int width;
	private Color[] pixels;

	public BitmapData(Texture2D texture)
	{
        height = texture.height;
        width = texture.width;
		pixels = texture.GetPixels();
	}

	public Color getPixelColor(int x, int y)
	{
		if (x >= width)
		{
			x = width - 1;
		}
		if (y >= height)
		{
			y = height - 1;
		}
		if (x < 0)
		{
			x = 0;
		}
		if (y < 0)
		{
			y = 0;
		}
		return pixels[y * width + x];
	}
}

[Serializable]
public class BitString
{
	public int len;

	public int val;
}

[Serializable]
public class buffer_class
{
	public FileStream file;

	public Vector2 resolution;

	public byte[] bytes;

	public ulong length;

	public Vector2 size;

	public tile_class tiles;

	public ulong pos;

	public ulong row;

	public Rect innerRect;

	public Rect outerRect;

	public Vector2 offset;

	public int radius;

	public buffer_class()
	{
		tiles = new tile_class();
	}

	public void init()
	{
		tiles.x = (int)Mathf.Ceil(resolution.x / size.x);
		tiles.y = (int)Mathf.Ceil(resolution.x / size.y);
		row = (ulong)(resolution.x * (float)3);
	}

	public void getRects(tile_class tile)
	{
		int num = radius + 20;
		innerRect.x = tile.x * size.x - 5;
		innerRect.y = tile.y * size.y - 5;
		innerRect.width = size.x + 10;
		innerRect.height = size.y + 10;
		if (innerRect.xMin < 0)
		{
			innerRect.xMin = 0;
		}
		if (innerRect.yMin < 0)
		{
            innerRect.yMin = 0;
		}
		if (innerRect.xMax > resolution.x)
		{
			innerRect.xMax = resolution.x;
		}
		if (innerRect.yMax > resolution.y)
		{
			innerRect.yMax = resolution.y;
		}
		outerRect.xMin = innerRect.xMin - num;
		outerRect.yMin = innerRect.yMin - num;
		outerRect.xMax = innerRect.xMax + num;
		outerRect.yMax = innerRect.yMax + num;

		if (outerRect.xMin < 0)
		{
            outerRect.xMin = 0;
		}
		else if (outerRect.xMax > resolution.x)
		{
			outerRect.xMax = resolution.x;
		}
		if (outerRect.yMin < 0)
		{
            outerRect.yMin = 0;
		}
		else if (outerRect.yMax > resolution.y)
		{
			outerRect.yMax = resolution.y;
		}

		length = (ulong)(outerRect.width * outerRect.height * 3);
		offset.x = innerRect.x - outerRect.x;
		offset.y = innerRect.y - outerRect.y;

        if (bytes == null)
		{
			bytes = new byte[(int)length];
		}
		if ((long)bytes.Length != (long)length)
		{
			bytes = new byte[(int)length];
		}
	}

	public void read()
	{
		int num = 0;
		while (num < outerRect.height)
		{
			pos = (ulong)(row * outerRect.y + ((long)row * (long)num) + outerRect.x * 3);
			file.Seek((long)pos, 0);
			file.Read(bytes, (int)(outerRect.width * num * 3), (int)(outerRect.width * 3));
			num++;
		}
	}

	public void write()
	{
		int num = 0;
		while (num < innerRect.height)
		{
			pos = (ulong)(row * innerRect.y + ((long)row * num) + innerRect.x * 3);
			file.Seek((long)pos, 0);
			file.Write(bytes, (int)(outerRect.width * num * 3 + outerRect.width * 3 * offset.y + offset.x * 3), (int)(innerRect.width * 3));
			num++;
		}
	}

	public void copy_bytes(byte[] bytes1, byte[] bytes2)
	{
		ulong num = 0;
		while ((long)num < bytes1.Length)
		{
			bytes2[(int)num] = bytes1[(int)num];
			num = (ulong)((long)num + (long)((ulong)1));
		}
	}

	public void clear_bytes()
	{
		ulong num = 0;
		while ((long)num < bytes.Length)
		{
			bytes[(int)num] = 0;
			num = (ulong)((long)num + (long)((ulong)1));
		}
	}
}

[Serializable]
public class ByteArray
{
	private MemoryStream stream;
	private BinaryWriter writer;

	public ByteArray()
	{
		stream = new MemoryStream();
		writer = new BinaryWriter(stream);
	}

	public void writeByte(byte value)
	{
		writer.Write(value);
	}

	public byte[] GetAllBytes()
	{
		byte[] array = new byte[(int)stream.Length];
		stream.Position = 0L;
		stream.Read(array, 0, array.Length);
		return array;
	}
}

[Serializable]
public class color_settings_class
{
	public Color backgroundColor;
	public bool backgroundActive;
	public Color color_description;
	public Color color_layer;
	public Color color_filter;
	public Color color_subfilter;
	public Color color_colormap;
	public Color color_splat;
	public Color color_tree;
	public Color color_tree_precolor_range;
	public Color color_tree_filter;
	public Color color_tree_subfilter;
	public Color color_grass;
	public Color color_object;
	public Color color_terrain;

	public color_settings_class()
	{
		backgroundColor = new Color(0, 0, 0, 0.5f);
		color_description = new Color(1, 0.45f, 0);
        color_layer = Color.yellow;
		color_filter = Color.cyan;
		color_subfilter = Color.green;
		color_colormap = Color.white;
		color_splat = Color.white;
		color_tree = new Color(1, 0.7f, 0.4f);
		color_tree_precolor_range = new Color(1, 0.84f, 0.64f);
		color_tree_filter = new Color(0.5f, 1, 1);
		color_tree_subfilter = new Color(0.5f, 1, 0.5f);
		color_grass = Color.white;
		color_object = Color.white;
		color_terrain = Color.white;
	}
}

[Serializable]
public enum condition_output_enum
{
	add,
	subtract,
	change,
	multiply,
	divide,
	difference,
	average,
	max,
	min
}

[Serializable]
public class detail_class
{
	public int[,] detail;
}

[Serializable]
public class detailPrototype_class
{
	public bool foldout;
	public GameObject prototype;
	public Texture2D previewTexture;
	public Texture2D prototypeTexture;
	public float minWidth;
	public float maxWidth;
	public float minHeight;
	public float maxHeight;
	public float noiseSpread;
	public float bendFactor;
	public Color healthyColor;
	public Color dryColor;
	public DetailRenderMode renderMode;
	public bool usePrototypeMesh;

	public detailPrototype_class()
	{
		minWidth = 1;
		maxWidth = 2;
		minHeight = 1;
		maxHeight = 2;
		noiseSpread = 0.1f;
        healthyColor = Color.white;
		dryColor = new Color(0.8f, 0.76f, 0.53f);
		renderMode = DetailRenderMode.Grass;
	}
}

[Serializable]
public class edit_class
{
	public string text;

	public string default_text;

	public bool edit;

	public bool disable_edit;

	public Rect rect;

	public edit_class()
	{
		this.text = string.Empty;
		this.default_text = string.Empty;
	}
}

[Serializable]
public class ext_class
{
	public WWW pull;
	public bool loaded;
	public bool converted;
	public int error;
	public tile_class tile;
	public tile_class subtile;
	public latlong_area_class latlong_area;
	public latlong_class latlong_center;
	public string url;
	public Vector2 bres;
	public int zero_error;
	public int download_error;
    public float startTime;
    
    public ext_class()
	{
		tile = new tile_class();
		subtile = new tile_class();
		latlong_area = new latlong_area_class();
		latlong_center = new latlong_class();
	}
}

[Serializable]
public class global_settings_class
{
	public bool undo;

	public bool positionSeed;

	public color_settings_class color;

	public bool color_scheme_display;

	public bool color_scheme;

	public bool toggle_text_no;

	public bool toggle_text_short;

	public bool toggle_text_long;

	public bool tooltip_text_no;

	public bool tooltip_text_short;

	public bool tooltip_text_long;

	public bool mac_mode;

	public int tooltip_mode;

	public WWW myExt;

	public WWW myExt2;

	public WWW myExt3;

	public WWW myExt4;

	public bool restrict_resolutions;

	public bool load_terrain_data;

	public bool rtp;

	public bool video_help;

	public bool view_only_output;

	public float save_global_timer;

	public WWW download;

	public int downloading;

	public bool download_foldout;

	public bool download_display;

	public WWW download2;

	public int downloading2;

	public bool download_foldout2;

	public bool download_display2;

	public WWW wc_contents;

	public int wc_loading;

	public float old_version;

	public float new_version;

	public bool update_display;

	public bool update_display2;

	public bool update_version;

	public bool update_version2;

	public string[] update;

	public float time_out;

	public bool button_export;

	public bool button_measure;

	public bool button_capture;

	public bool button_tools;

	public bool button_tiles;

	public bool button_node;

	public bool button_world;

	public bool example_display;

	public int example_resolution;

	public Vector2 exampleTerrainTiles;

	public int example_terrain;

	public int example_terrain_old1;

	public bool example_tree_active;

	public bool example_grass_active;

	public bool example_object_active;

	public int example_buttons;

	public global_settings_class()
	{
		this.positionSeed = true;
		this.color = new color_settings_class();
		this.color_scheme = true;
		this.toggle_text_short = true;
		this.tooltip_text_long = true;
		this.tooltip_mode = 2;
		this.restrict_resolutions = true;
		this.video_help = true;
		this.view_only_output = true;
		this.save_global_timer = (float)5;
		this.download_foldout = true;
		this.download_display = true;
		this.download_foldout2 = true;
		this.download_display2 = true;
		this.update = new string[]
		{
			"Don't check",
			"Notify",
			"Download and notify",
			"Download,import and notify",
			"Download and import automatically"
		};
		this.button_export = true;
		this.button_measure = true;
		this.button_capture = true;
		this.button_tools = true;
		this.button_tiles = true;
		this.button_node = true;
		this.button_world = true;
		this.example_display = true;
		this.example_resolution = 3;
		this.exampleTerrainTiles = new Vector2((float)2, (float)2);
		this.example_terrain_old1 = -1;
		this.example_tree_active = true;
		this.example_grass_active = true;
		this.example_object_active = true;
		this.example_buttons = 1;
	}
}

[Serializable]
public class map_area_class
{
	public string name;
	public latlong_class upper_left;
	public latlong_class lower_right;
	public latlong_class center;
	public int center_height;
	public map_pixel_class size;
	public bool normalizeHeightmap;
	public float normalizedHeight;
	public bool created;
	public bool resize;
	public bool resize_left;
	public bool resize_right;
	public bool resize_top;
	public bool resize_bottom;
	public bool resize_topLeft;
	public bool resize_topRight;
	public bool resize_bottomLeft;
	public bool resize_bottomRight;
	public bool resize_center;
	public bool manual_area;
	public Vector2 heightmap_offset;
	public Vector2 heightmap_offset_e;
	public Vector2 image_offset_e;
	public bool image_stop_one;
	public int select;
	public float smooth_strength;
	public float width;
	public float height;
	public Vector2 heightmap_resolution;
	public double heightmap_scale;
	public int heightmap_zoom;
	public int elevation_zoom;
	public bool heightmap_manual;
	public double area_resolution;
	public int resolution;
	public int image_zoom;
	public bool image_changed;
	public bool start_tile_enabled;
	public tile_class start_tile;
	public tile_class tiles;
	public bool export_heightmap_active;
	public bool export_heightmap_call;
	public string export_heightmap_path;
	public string export_heightmap_filename;
	public bool export_heightmap_changed;
	public bool export_heightmap_not_fit;
	public Vector2 export_heightmap_bres;
	public bool export_image_active;
	public bool export_image_call;
	public string export_image_path;
	public string export_image_filename;
	public bool export_image_changed;
	public bool export_image_import_settings;
    public bool export_image_world_file;
	public string export_terrain_path;
	public bool export_terrain_changed;
	public bool export_to_terraincomposer;
	public string import_heightmap_path_full;
	public bool import_heightmap;
	public bool filter_perlin;
	public string converter_source_path_full;
	public string converter_destination_path_full;
	public Vector2 converter_resolution;
	public float converter_height;
	public bool converter_import_heightmap;
	public string terrain_asset_name;
	public string terrain_scene_name;
	public bool terrain_name_changed;
	public float terrain_scale;
	public AnimationCurve terrain_curve;
	public bool do_heightmap;
	public bool do_image;
    public int terrain_heightmap_resolution_select;
	public int terrain_heightmap_resolution;
	public bool terrain_heightmap_resolution_changed;
	public bool mipmapEnabled;
	public bool terrain_done;
	public FilterMode filterMode;
	public int anisoLevel;
	public int maxTextureSize;
	public int maxTextureSize_select;
	public bool maxTextureSize_changed;
	public bool auto_import_settings_apply;
	public bool preimage_export_active;
	public bool preimage_apply;
	public bool preimage_save_new;
	public string preimage_path;
	public bool preimage_path_changed;
	public string preimage_filename;
	public int preimage_count;
    public TextureImporterFormat textureFormat;
     
    public map_area_class(string name1, int index)
	{
		this.name = "Untitled";
		this.upper_left = new latlong_class();
		this.lower_right = new latlong_class();
		this.center = new latlong_class();
		this.size = new map_pixel_class();
		this.normalizeHeightmap = true;
		this.heightmap_offset = new Vector2((float)0, (float)0);
		this.smooth_strength = (float)1;
		this.resolution = 2048;
		this.image_zoom = 18;
		this.start_tile = new tile_class();
		this.tiles = new tile_class();
		this.export_heightmap_path = string.Empty;
		this.export_heightmap_filename = string.Empty;
		this.export_image_path = string.Empty;
		this.export_image_filename = string.Empty;
		this.export_terrain_path = string.Empty;
		this.export_to_terraincomposer = true;
		this.converter_source_path_full = string.Empty;
		this.converter_destination_path_full = string.Empty;
		this.converter_height = (float)10000;
		this.terrain_asset_name = string.Empty;
		this.terrain_scene_name = string.Empty;
		this.terrain_scale = (float)1;
		this.do_heightmap = true;
		this.do_image = true;
		this.mipmapEnabled = true;
		this.filterMode = FilterMode.Trilinear;
		this.anisoLevel = 9;
		this.maxTextureSize_select = 6;
		this.auto_import_settings_apply = true;
		this.preimage_path = string.Empty;
		this.name = name1 + index.ToString();
		this.terrain_curve = AnimationCurve.Linear((float)0, (float)0, (float)1, (float)1);
		this.terrain_curve.AddKey((float)1, (float)0);
		this.terrain_curve = this.set_curve_linear(this.terrain_curve);

        #if UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
        textureFormat = TextureImporterFormat.AutomaticCompressed;
        #endif
    }

	public void reset()
	{
		this.upper_left.reset();
		this.lower_right.reset();
		this.center.reset();
		this.size.reset();
	}

	public AnimationCurve set_curve_linear(AnimationCurve curve)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		for (int i = 0; i < curve.length; i++)
		{
			float inTangent = (float)0;
			float outTangent = (float)0;
			bool flag = false;
			bool flag2 = false;
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			Vector2 vector3 = default(Vector2);
			Keyframe keyframe = curve[i];
			if (i == 0)
			{
				inTangent = (float)0;
				flag = true;
			}
			if (i == curve.length - 1)
			{
				outTangent = (float)0;
				flag2 = true;
			}
			if (!flag)
			{
				vector.x = curve[i - 1].time;
				vector.y = curve[i - 1].value;
				vector2.x = curve[i].time;
				vector2.y = curve[i].value;
				vector3 = vector2 - vector;
				inTangent = vector3.y / vector3.x;
			}
			if (!flag2)
			{
				vector.x = curve[i].time;
				vector.y = curve[i].value;
				vector2.x = curve[i + 1].time;
				vector2.y = curve[i + 1].value;
				vector3 = vector2 - vector;
				outTangent = vector3.y / vector3.x;
			}
			keyframe.inTangent = inTangent;
			keyframe.outTangent = outTangent;
			animationCurve.AddKey(keyframe);
		}
		return animationCurve;
	}
}

[Serializable]
public class map_class
{
	public map_type_enum type;

	public int timeOut;

	public bool active;

	public bool button_parameters;

	public bool button_image_editor;

	public bool button_region;

	public bool button_image_export;

	public bool button_heightmap_export;

	public bool button_converter;

	public bool button_settings;

	public bool button_create_terrain;

	public bool button_help;

	public bool button_update;

	public float alpha;

	public Color backgroundColor;

	public Color titleColor;

	public Color errorColor;

	public bool region_popup_edit;

	public bool area_popup_edit;

	public bool disable_region_popup_edit;

	public bool disable_area_popup_edit;

	public List<map_region_class> region;

	public string[] region_popup;

	public int region_select;

	public bool manual_edit;

	public Rect region_rect;

	public Rect area_rect;

	public preimage_edit_class preimage_edit;

	public Color color_fault;

	public Texture2D tex1;

	public Texture2D tex2;

	public Texture2D tex3;

	public FileStream file_tex2;

	public FileStream file_tex3;

	public bool tex_swapped;

	public tile_class tex2_tile;

	public tile_class tex3_tile;

	public WWW elExt_check;

	public bool elExt_check_loaded;

	public bool elExt_check_assign;

	public List<ext_class> elExt;

	public List<ext_class> texExt;
    
	public int export_texExt;

	public int export_elExt;

	public int mode;

	public bool export_tex3;

	public bool export_tex2;

	public latlong_area_class export_heightmap_area;

	public latlong_area_class export_image_area;

	public tile_class export_pullIndex;

	public int export_pulled;

	public bool export_image_active;

	public bool export_heightmap_active;

	public int export_heightmap_zoom;

	public float export_heightmap_timeStart;

	public float export_heightmap_timeEnd;

	public float export_heightmap_timePause;

	public bool export_heightmap_continue;

	public map_export_class export_heightmap;

	public map_export_class export_image;

	public int export_image_zoom;

	public float export_image_timeStart;

	public float export_image_timeEnd;

	public float export_image_timePause;

	public bool export_image_continue;

	public int export_jpg_quality;

	public bool export_jpg;

	public bool export_png;

	public bool export_raw;

	public Color color;

	public bool key_edit;

	public List<map_key_class> bingKey;

	public int bingKey_selected;

	public float mouse_sensivity;

	public bool path_display;

	public bool warnings;

	public bool track_tile;

	public bool snap;

	public float snapValue;

	public map_class()
	{
		this.timeOut = 4;
		this.active = true;
		this.button_parameters = true;
		this.button_image_editor = true;
		this.button_region = true;
		this.button_image_export = true;
		this.button_heightmap_export = true;
		this.button_settings = true;
		this.alpha = 0.65f;
		this.errorColor = new Color(0.498039216f, 0.498039216f, 0.498039216f);
		this.region = new List<map_region_class>();
		this.preimage_edit = new preimage_edit_class();
		this.tex2_tile = new tile_class();
		this.tex3_tile = new tile_class();
		this.elExt = new List<ext_class>();
		this.texExt = new List<ext_class>();
		
		this.export_texExt = 8;
		this.export_elExt = 16;
		this.export_heightmap_area = new latlong_area_class();
		this.export_image_area = new latlong_area_class();
		this.export_pullIndex = new tile_class();
		this.export_heightmap_continue = true;
		this.export_heightmap = new map_export_class();
		this.export_image = new map_export_class();
		this.export_image_continue = true;
		this.export_jpg_quality = 100;
		this.export_jpg = true;
        this.color = Color.red;
		this.bingKey = new List<map_key_class>();
		this.mouse_sensivity = (float)2;
		this.warnings = true;
		this.track_tile = true;
		this.snapValue = 0.1f;
		this.make_region_popup();
	}

	public void make_region_popup()
	{
		this.region_popup = new string[region.Count];
		for (int i = 0; i < this.region.Count; i++)
		{
			this.region_popup[i] = this.region[i].name;
		}
	}
}

[Serializable]
public class map_export_class
{
	public bool last_tile;

	public tile_class tiles;

	public tile_class tile;

	public tile_class subtiles;

	public tile_class subtile;

	public int subtiles_total;

	public int subtile_total;

	public int subtile2_total;

	public float progress;

	public map_export_class()
	{
		this.tiles = new tile_class();
		this.tile = new tile_class();
		this.subtiles = new tile_class();
		this.subtile = new tile_class();
	}
}

[Serializable]
public class map_key_class
{
	public int pulls_startDay;

	public int pulls_startHour;

	public int pulls_startMinute;

	public int pulls;

	public string key;

	public void reset()
	{
		this.pulls = 0;
		this.pulls_startDay = DateTime.Now.Day;
		this.pulls_startHour = DateTime.Now.Hour;
		this.pulls_startMinute = DateTime.Now.Minute;
	}
}

[Serializable]
public class map_region_class
{
	public string name;

	public List<map_area_class> area;

	public string[] area_popup;

	public int area_select;

	public latlong_class center;

	public map_region_class(int index)
	{
		this.name = "Untitled";
		this.area = new List<map_area_class>();
		this.center = new latlong_class();
		this.name += index.ToString();
	}

	public void make_area_popup()
	{
		this.area_popup = new string[this.area.Count];
		for (int i = 0; i < this.area.Count; i++)
		{
			this.area_popup[i] = this.area[i].name;
		}
	}
}

[Serializable]
public enum map_type_enum
{
	Aerial,
	AerialWithLabels,
	Road
}

[Serializable]
public class neighbor_class
{
	public int left;

	public int right;

	public int top;

	public int bottom;

	public int top_left;

	public int top_right;

	public int bottom_left;

	public int bottom_right;

	public int self;

	public neighbor_class()
	{
		this.left = -1;
		this.right = -1;
		this.top = -1;
		this.bottom = -1;
		this.top_left = -1;
		this.top_right = -1;
		this.bottom_left = -1;
		this.bottom_right = -1;
	}
}

[Serializable]
public class preimage_edit_class
{
	public List<image_edit_class> edit_color;
	public int y1, x1, x, y;
	public float frames;
	public float auto_speed_time;
	private float target_frame;
	public float time_start;
	public float time;
	public bool generate;
	public bool loop;
	public bool generate_call;
	public bool active;
	public bool loop_active;
	public bool import_settings;
	public bool regen;
	public bool regenRaw;
	public bool border;
	public float progress;
	public Vector2 resolution;
	public Vector2 resolutionRaw;
	public byte[] byte1;
	public bool raw;
	public int xx;
	public Vector2 position;
	public Vector2 position2;
	public Vector2 direction;
	public int dir;
	public Vector2 pos_old;
	public bool first;
	public int count;
	public buffer_class inputBuffer;
	public buffer_class outputBuffer;
	public int radius;
	public int radiusSelect;
	public int mode;
	public tile_class tile;
	public int repeat;
	public int repeatAmount;
	public bool content;

	public preimage_edit_class()
	{
		edit_color = new List<image_edit_class>();
		target_frame = (float)30;
		active = true;
		loop_active = true;
		byte1 = new byte[3];
		xx = 3;
		position = new Vector2((float)(this.x - 1), (float)(this.y - 1));
		direction = new Vector2((float)1, (float)0);
		dir = 1;
		inputBuffer = new buffer_class();
		outputBuffer = new buffer_class();
		radius = 300;
		radiusSelect = 300;
		mode = 1;
		tile = new tile_class();
		repeatAmount = 3;
		content = true;
	}

	public float calc_color_pos(Color color, Color color_start, Color color_end)
	{
        Color color_start2 = color_start;
        Color color_range;
        if (color_start.r > color_end.r) { color_start.r = color_end.r; color_end.r = color_start2.r; }
        if (color_start.g > color_end.g) { color_start.g = color_end.g; color_end.g = color_start2.g; }
        if (color_start.b > color_end.b) { color_start.b = color_end.b; color_end.b = color_start2.b; }
        color_range = color_end - color_start;
        color -= color_start;
        if (color.r < 0 || color.g < 0 || color.b < 0) { return -1; }
        if (color.r > color_range.r || color.g > color_range.g || color.b > color_range.b) { return -1; }

        float color_range_total = (color_range.r + color_range.g + color_range.b);
        float color_total = (color.r + color.g + color.b);
        if (color_range_total != 0) { return (color_total / color_range_total); } else { return 1; }
    }

	public Color calc_color_from_pos(float pos, Color color_start, Color color_end)
	{
        Color color_start2 = color_start;
        Color color_range;
        if (color_start.r > color_end.r) { color_start.r = color_end.r; color_end.r = color_start2.r; }
        if (color_start.g > color_end.g) { color_start.g = color_end.g; color_end.g = color_start2.g; }
        if (color_start.b > color_end.b) { color_start.b = color_end.b; color_end.b = color_start2.b; }
        color_range = color_end - color_start;

        Color color = color_start + new Color(color_range.r * pos, color_range.g * pos, color_range.b * pos);
        // if (color_range_total != 0){return (color_total/color_range_total);} else {return 1;}
        return color;
    }

	public void swap_color(int color_index1, int color_index2)
	{
		image_edit_class image_edit_class = edit_color[color_index1];
		edit_color[color_index1] = edit_color[color_index2];
		edit_color[color_index2] = image_edit_class;
	}

	public void copy_color(int color_index1, int color_index2)
	{
        edit_color[color_index1].color1_start = edit_color[color_index2].color1_start;
        edit_color[color_index1].color1_end = edit_color[color_index2].color1_end;
        edit_color[color_index1].curve1 = edit_color[color_index2].curve1;
        edit_color[color_index1].color2_start = edit_color[color_index2].color2_start;
        edit_color[color_index1].color2_end = edit_color[color_index2].color2_end;
        edit_color[color_index1].curve2 = edit_color[color_index2].curve2;
        edit_color[color_index1].strength = edit_color[color_index2].strength;
        edit_color[color_index1].output = edit_color[color_index2].output;
        edit_color[color_index1].active = edit_color[color_index2].active;
        edit_color[color_index1].solid_color = edit_color[color_index2].solid_color;
    }

	public void convert_texture_raw(bool multithread)
	{
        int count_color = 0;
        Color color, color2, color3;
        float color_pos1, color_pos2;
        float strength;
        
        // frames = 1/(Time.realtimeSinceStartup-auto_speed_time);
        auto_speed_time = Time.realtimeSinceStartup;
        pos_old.y = -100;

        for (y = y1; y < (inputBuffer.innerRect.height + inputBuffer.offset.y); ++y)
        {
            xx = 3;
            position = new Vector2(-1, y - 1);
            direction = new Vector2(1, 0);
            dir = 1;
            count = 0;

            for (x = (int)inputBuffer.offset.x + x1; x < (inputBuffer.innerRect.width + inputBuffer.offset.x); ++x)
            {
                color = GetPixelRaw(inputBuffer, x, y);
                color3 = color;

                for (count_color = 0; count_color < edit_color.Count; ++count_color)
                {
                    if ((edit_color[count_color].active || edit_color[count_color].solid_color))
                    {
                        color_pos1 = calc_color_pos(color, edit_color[count_color].color1_start, edit_color[count_color].color1_end);

                        if (color_pos1 != -1)
                        {
                            color_pos1 = edit_color[count_color].curve1.Evaluate(color_pos1);
                            color_pos2 = edit_color[count_color].curve2.Evaluate(color_pos1);
                            color2 = calc_color_from_pos(color_pos2, edit_color[count_color].color2_start, edit_color[count_color].color2_end);
                            strength = edit_color[count_color].strength;

                            if (!edit_color[count_color].solid_color)
                            {
                                if (edit_color[count_color].output == image_output_enum.content)
                                {
                                    if (x == pos_old.x + 1 && y == pos_old.y && xx > 3)
                                    {
                                        if (dir == 1)
                                        {
                                            if (count == 0)
                                            {
                                                position.x += 1;
                                                xx -= 2;
                                            }
                                            else
                                            {
                                                --count;
                                            }
                                        }
                                        else if (dir == 2)
                                        {
                                            xx -= 2;
                                        }
                                        else if (dir == 3 || dir == 4)
                                        {
                                            position.x = x + ((xx - 1) / 2);
                                            position.y = y - ((xx - 1) / 2);
                                            dir = 2;
                                            count = 0;
                                            direction = new Vector2(-1, 0);
                                        }
                                        color2 = content_fill_raw(x, y, edit_color[count_color].color1_start, edit_color[count_color].color1_end, edit_color[count_color].color2_start, false);
                                    }
                                    else
                                    {
                                        color2 = content_fill_raw(x, y, edit_color[count_color].color1_start, edit_color[count_color].color1_end, edit_color[count_color].color2_start, true);
                                    }
                                    pos_old = new Vector2(x, y);
                                    color3 = color2;
                                }

                                switch (edit_color[count_color].output)
                                {
                                    case image_output_enum.add:
                                        color3.r += color2.r * strength;
                                        color3.g += color2.g * strength;
                                        color3.b += color2.b * strength;
                                        break;
                                    case image_output_enum.subtract:
                                        color3.r -= color2.r * strength;
                                        color3.g -= color2.g * strength;
                                        color3.b -= color2.b * strength;
                                        break;
                                    case image_output_enum.change:
                                        color3.r = (color.r * (1 - strength)) + color2.r * strength;
                                        color3.g = (color.g * (1 - strength)) + color2.g * strength;
                                        color3.b = (color.b * (1 - strength)) + color2.b * strength;
                                        break;
                                    case image_output_enum.multiply:
                                        color3.r *= (color2.r * strength);
                                        color3.g *= (color2.g * strength);
                                        color3.b *= (color2.b * strength);
                                        break;
                                    case image_output_enum.divide:
                                        if ((color2.r * strength) != 0)
                                        {
                                            color3.r = color.r / (color2.r * strength);
                                        }
                                        if ((color2.g * strength) != 0)
                                        {
                                            color3.g = color.g / (color2.g * strength);
                                        }
                                        if ((color2.b * strength) != 0)
                                        {
                                            color3.b = color.b / (color2.b * strength);
                                        }
                                        break;
                                    case image_output_enum.difference:
                                        color3.r = Mathf.Abs((color2.r * strength) - color.r);
                                        color3.g = Mathf.Abs((color2.g * strength) - color.g);
                                        color3.b = Mathf.Abs((color2.b * strength) - color.b);
                                        break;
                                    case image_output_enum.average:
                                        color3.r = (color.r + (color2.r * strength)) / 2;
                                        color3.g = (color.g + (color2.g * strength)) / 2;
                                        color3.b = (color.b + (color2.b * strength)) / 2;
                                        break;
                                    case image_output_enum.max:
                                        if (color2.r * strength > color.r) { color3.r = color2.r * strength; }
                                        if (color2.g * strength > color.g) { color3.g = color2.g * strength; }
                                        if (color2.b * strength > color.b) { color3.b = color2.b * strength; }
                                        break;
                                    case image_output_enum.min:
                                        if (color2.r * strength < color.r) { color3.r = color2.r * strength; }
                                        if (color2.g * strength < color.g) { color3.g = color2.g * strength; }
                                        if (color2.b * strength < color.b) { color3.b = color2.b * strength; }
                                        break;
                                }
                            }
                            else
                            {
                                color3.r += 1 - color_pos1;
                                color3.g += color_pos1;
                                color3.b += 1;
                            }
                        }
                    }
                }
                if (color3[0] > 1) { color3[0] = 1; }
                else if (color3[0] < 0) { color3[0] = 0; }
                if (color3[1] > 1) { color3[1] = 1; }
                else if (color3[1] < 0) { color3[1] = 0; }
                if (color3[2] > 1) { color3[2] = 1; }
                else if (color3[2] < 0) { color3[2] = 0; }

                SetPixelRaw(outputBuffer, x, y, color3);

                if (Time.realtimeSinceStartup - auto_speed_time > (1.0 / target_frame) && multithread)
                {
                    y1 = y;
                    x1 = (int)(x - inputBuffer.offset.x) + 1;
                    // Debug.Log(y1);
                    if (mode == 2) { time = Time.realtimeSinceStartup - time_start; }
                    // Debug.Log("mode: "+mode+", "+y1);
                    return;
                }
            }
            x1 = 0;
        }
        generate = false;
    }

	public Color content_fill_raw(int _x, int _y, Color exclude_start, Color exclude_end, Color exclude2, bool reset)
	{
		Color color = default(Color);
		Color color2 = default(Color);
		Color color3 = default(Color);
		float num = (float)0;
		float num2 = (float)360;
		float num3 = (float)20;
		Vector2 vector3 = default(Vector2);
		Vector2 vector4 = default(Vector2);
		float num4 = default(float);
		float num5 = default(float);
		bool flag = false;
		bool flag2 = false;
		if (reset)
		{
			this.xx = 3;
			this.position = new Vector2((float)(_x - 1), (float)(_y - 1));
			this.direction = new Vector2((float)1, (float)0);
			this.dir = 1;
			this.count = 0;
		}
		do
		{
			color = this.GetPixelRaw(this.inputBuffer, (long)this.position.x, (long)this.position.y);
			if (!this.color_in_range(exclude_start, exclude_end, color))
			{
				break;
			}
			this.count++;
			if (this.count >= this.xx && this.dir == 1)
			{
				this.direction = new Vector2((float)0, (float)1);
				this.count = 0;
				this.dir = 2;
			}
			else if (this.count >= this.xx - 1 && this.dir == 2)
			{
				this.direction = new Vector2((float)-1, (float)0);
				this.count = 0;
				this.dir = 3;
			}
			else if (this.count >= this.xx - 1 && this.dir == 3)
			{
				this.direction = new Vector2((float)0, (float)-1);
				this.count = 0;
				this.dir = 4;
			}
			else if (this.count >= this.xx - 2 && this.dir == 4)
			{
				this.direction = new Vector2((float)1, (float)0);
				this.count = 0;
				this.position += new Vector2((float)-1, (float)-2);
				this.dir = 1;
				this.xx += 2;
				continue;
			}
			this.position += this.direction;
		}
		while (!flag);
		vector3.x = this.position.x - (float)_x;
		vector3.y = this.position.y - (float)_y;
		num4 = vector3.magnitude;
		if (this.repeat < 1 && num4 > (float)4)
		{
			int num8 = (int)(this.position.y - (float)1);
			while ((float)num8 <= this.position.y + (float)1)
			{
				int num9 = (int)(this.position.x - (float)1);
				while ((float)num9 <= this.position.x + (float)1)
				{
					color2 = this.GetPixelRaw(this.inputBuffer, (long)num9, (long)num8);
					if (color2[0] <= exclude2[0] && color2[1] <= exclude2[1] && color2[2] <= exclude2[2])
					{
						this.SetPixelRaw(this.outputBuffer, (long)num9, (long)num8, new Color((float)0, (float)0, (float)0));
					}
					num9++;
				}
				num8++;
			}
		}
		if (this.repeat < this.repeatAmount - 1)
		{
			vector4 = vector3 / num4 * (float)this.radius;
			this.position2.x = (float)_x + vector4.x;
			this.position2.y = (float)_y + vector4.y;
			color = this.GetPixelRaw(this.inputBuffer, (long)this.position2.x, (long)this.position2.y);
			if (this.color_in_range(exclude_start, exclude_end, color))
			{
				this.regen = true;
				flag2 = true;
			}
		}
		if (!flag2)
		{
			color2 = this.GetPixelRaw(this.outputBuffer, (long)(_x - 1), (long)_y);
			if (!this.color_in_range(exclude_start, exclude_end, color2))
			{
				num5 = (float)this.color_difference(color2, color);
				if (this.GetPixelRaw(this.inputBuffer, (long)(_x - 1), (long)_y) == color2)
				{
					num5 *= (float)10;
				}
				if (num5 > num3)
				{
					color3 += color2 * (num5 / num2);
					num += num5 / num2;
				}
			}
			color2 = this.GetPixelRaw(this.outputBuffer, (long)_x, (long)(_y - 1));
			if (!this.color_in_range(exclude_start, exclude_end, color2))
			{
				num5 = (float)this.color_difference(color2, color);
				if (this.GetPixelRaw(this.inputBuffer, (long)_x, (long)(_y - 1)) == color2)
				{
					num5 *= (float)10;
				}
				if (num5 > num3)
				{
					color3 += color2 * (num5 / num2);
					num += num5 / num2;
				}
			}
			color2 = this.GetPixelRaw(this.outputBuffer, (long)(_x + 1), (long)_y);
			if (!this.color_in_range(exclude_start, exclude_end, color2))
			{
				num5 = (float)this.color_difference(color2, color);
				if (this.GetPixelRaw(this.inputBuffer, (long)(_x + 1), (long)_y) == color2)
				{
					num5 *= (float)10;
				}
				if (num5 > num3)
				{
					color3 += color2 * (num5 / num2);
					num += num5 / num2;
				}
			}
			color2 = this.GetPixelRaw(this.outputBuffer, (long)_x, (long)(_y + 1));
			if (!this.color_in_range(exclude_start, exclude_end, color2))
			{
				num5 = (float)this.color_difference(color2, color);
				if (this.GetPixelRaw(this.inputBuffer, (long)_x, (long)(_y + 1)) == color2)
				{
					num5 *= (float)10;
				}
				if (num5 > num3)
				{
					color3 += color2 * (num5 / num2);
					num += num5 / num2;
				}
			}
			color += color3;
			color /= (float)1 + num;
		}
		this.SetPixelRaw(this.outputBuffer, (long)_x, (long)_y, color);
		return color;
	}

	public Color GetPixelRaw(buffer_class buffer, long x, long y)
	{
        if (mode == 1)
        {
            if (x < 0) { x = 0 - x; }
            else if (x > buffer.outerRect.width - 1) { x = (int)(x - (x - (buffer.outerRect.width - 1))); }
            if (y < 0) { y = 0 - y; }
            else if (y > buffer.outerRect.height - 1) { y = (int)(y - (y - (buffer.outerRect.height - 1))); }
        }
        else
        {
            if (x < 0 || x > buffer.outerRect.width - 1 || y < 0 || y > buffer.outerRect.height - 1)
            {
                return GetPixelRaw2(buffer, x, y);
            }
        }

        ulong pos = (ulong)((buffer.outerRect.width * 3 * y) + (x * 3));
        // if (pos > buffer.bytes.Length-3) {pos = buffer.bytes.Length-3;}
        // Debug.Log(file.length+" pos: "+pos+" x: "+x+" y: "+y); 

        return new Color((buffer.bytes[pos] * 1.0f) / 255, (buffer.bytes[pos + 1] * 1.0f) / 255, (buffer.bytes[pos + 2] * 1.0f) / 255);
    }

	public void SetPixelRaw(buffer_class buffer, long x, long y, Color color)
	{
		if (x < 0L)
		{
			x = 0L - x;
		}
		else if ((float)x > buffer.outerRect.width - (float)1)
		{
			x = (long)((float)x - ((float)x - (buffer.outerRect.width - (float)1)));
		}
		if (y < 0L)
		{
			y = 0L - y;
		}
		else if ((float)y > buffer.outerRect.height - (float)1)
		{
			y = (long)((float)y - ((float)y - (buffer.outerRect.height - (float)1)));
		}
		ulong num = (ulong)(buffer.outerRect.width * (float)3 * (float)y + (float)(x * 3L));
		buffer.bytes[(int)num] = (byte)(color[0] * (float)255);
		buffer.bytes[(int)((long)num + (long)((ulong)1))] = (byte)(color[1] * (float)255);
		buffer.bytes[(int)((long)num + (long)((ulong)2))] = (byte)(color[2] * (float)255);
	}

	public Color GetPixelRaw2(buffer_class buffer, long x, long y)
	{
		x = (long)((float)x + buffer.outerRect.x);
		y = (long)((float)y + buffer.outerRect.y);
		if (x < 0L)
		{
			x = -x;
		}
		else if ((float)x > buffer.resolution.x - (float)1)
		{
			x = (long)((float)x - ((float)x - buffer.resolution.x - (float)1));
		}
		if (y < 0L)
		{
			y = -y;
		}
		else if ((float)y > buffer.resolution.y - (float)1)
		{
			y = (long)((float)y - ((float)y - buffer.resolution.y - (float)1));
		}
		ulong num = (ulong)((long)buffer.row * y + x * 3L);
		buffer.file.Seek((long)num, 0);
		byte[] array = new byte[3];
		buffer.file.Read(array, 0, 3);
		return new Color((float)array[0] * 1f / (float)255, (float)array[1] * 1f / (float)255, (float)array[2] * 1f / (float)255);
	}

	public bool color_in_range(Color color_start, Color color_end, Color color)
	{
		return color[0] >= color_start[0] && color[0] <= color_end[0] && color[1] >= color_start[1] && color[1] <= color_end[1] && color[2] >= color_start[2] && color[2] <= color_end[2];
	}

	public int color_difference(Color color1, Color color2)
	{
		return (int)((Mathf.Abs(color1[0] - color2[0]) + Mathf.Abs(color1[1] - color2[1]) + Mathf.Abs(color1[2] - color2[1])) * (float)255);
	}
}

[Serializable]
public class raw_file_class
{
	public bool assigned;

	public bool created;

	public string file;

	public string filename;

	public raw_mode_enum mode;

	public int length;

	public Vector2 resolution;

	public bool square;

	public bool loaded;

	public bool linked;

	public byte[] bytes;

	public FileStream fs;

	public float product1;

	public float product2;

	public raw_file_class()
	{
		this.created = true;
		this.file = string.Empty;
		this.filename = string.Empty;
		this.mode = raw_mode_enum.Windows;
		this.square = true;
		this.linked = true;
	}

	public bool exists()
	{
		FileInfo fileInfo = new FileInfo(this.file);
		return fileInfo.Exists;
	}
}

[Serializable]
public enum raw_mode_enum
{
	Windows,
	Mac
}

[Serializable]
public class remarks_class
{
	public bool textfield_foldout;

	public int textfield_length;

	public string textfield;

	public remarks_class()
	{
		this.textfield_length = 1;
		this.textfield = string.Empty;
	}
}

[Serializable]
public enum resolution_mode_enum
{
	Automatic,
	Heightmap,
	Splatmap,
	Tree,
	Detailmap,
	Object,
	Units,
	Custom,
	Colormap
}

[Serializable]
public class select_window_class
{
	public bool active;

	public bool button_colormap;

	public bool button_node;

	public bool button_terrain;

	public bool button_heightmap;

	public float terrain_zoom;

	public float terrain_zoom2;

	public Vector2 terrain_pos;

	public float node_zoom;

	public float node_zoom2;

	public Vector2 node_pos;

	public bool node_grid;

	public bool node_grid_center;

	public int mode;

	public Vector2 terrain_offset;

	public Vector2 node_offset;

	public select_window_class()
	{
		this.button_heightmap = true;
		this.terrain_zoom = (float)40;
		this.terrain_zoom2 = (float)40;
		this.terrain_pos = new Vector2((float)0, (float)0);
		this.node_zoom = (float)40;
		this.node_zoom2 = (float)40;
		this.node_pos = new Vector2((float)0, (float)0);
		this.node_grid = true;
		this.node_grid_center = true;
		this.terrain_offset = new Vector2((float)0, (float)0);
		this.node_offset = new Vector2((float)0, (float)0);
	}

	public void select_colormap()
	{
		this.button_node = false;
		this.button_colormap = true;
		this.button_terrain = false;
	}

	public void select_terrain()
	{
		this.button_node = false;
		this.button_colormap = false;
		this.button_terrain = true;
	}

	public void select_node()
	{
		this.button_node = true;
		this.button_colormap = false;
		this.button_terrain = false;
	}
}

[Serializable]
public class splatPrototype_class
{
	public bool foldout;

	public Texture2D texture;

	public Vector2 tileSize;

	public bool tileSize_link;

	public Vector2 tileSize_old;

	public Vector2 tileOffset;

	public Vector2 normal_tileSize;

	public float strength;

	public float strength_splat;

	public Texture2D normal_texture;

	public Texture2D normalMap;

	public Texture2D height_texture;

	public Texture2D specular_texture;

	public int import_max_size_list;

	public splatPrototype_class()
	{
		this.tileSize = new Vector2((float)10, (float)10);
		this.tileSize_link = true;
		this.tileOffset = new Vector2((float)0, (float)0);
		this.normal_tileSize = new Vector2((float)10, (float)10);
		this.strength = (float)1;
		this.strength_splat = (float)1;
	}
}

public static class TC
{
	public static Type[] GetAllSubTypes(Type aBaseClass)
	{
		List<Type> list = new List<Type>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		int i = 0;
		Assembly[] array = assemblies;
		int length = array.Length;
		while (i < length)
		{
			Type[] types = array[i].GetTypes();
			int j = 0;
			Type[] array2 = types;
			int length2 = array2.Length;
			while (j < length2)
			{
				if (array2[j].IsSubclassOf(aBaseClass))
				{
					list.Add(array2[j]);
				}
				j++;
			}
			i++;
		}
		return list.ToArray();
	}

	public static Type GetType(Type t, string typeName)
	{
		int i = 0;
		Type[] allSubTypes = TC.GetAllSubTypes(t);
		int length = allSubTypes.Length;
		Type arg_3C_0;
		while (i < length)
		{
			if (allSubTypes[i].Name == typeName)
			{
				arg_3C_0 = allSubTypes[i];
				return arg_3C_0;
			}
			i++;
		}
		arg_3C_0 = null;
		return arg_3C_0;
	}
}

[Serializable]
public class terrain_area_class
{
	public List<terrain_class2> terrains;
	public int index;
	public tile_class tiles;
	public tile_class tiles_select;
	public int tiles_total;
	public int tiles_select_total;
	public int tiles_assigned_total;
	public bool tiles_select_link;
	public Vector3 size;
	public Vector3 center;
	public bool edit;
	public bool disable_edit;
	public bool area_foldout;
	public bool tiles_foldout;
	public bool settings_foldout;
	public bool center_synchronous;
	public bool tile_synchronous;
	public bool tile_position_synchronous;
	public Rect rect;
	public Rect rect1;
	public string text;
	public string text_edit;
	public bool display_short;
	public remarks_class remarks;
	public bool copy_settings;
	public int copy_terrain;
	public bool foldout;
	public bool terrains_active;
	public bool terrains_scene_active;
	public bool terrains_foldout;
	public auto_search_class auto_search;
	public auto_search_class auto_name;
	public string path;
	public Transform parent;
	public string scene_name;
	public string asset_name;
	public bool resize;
	public bool resize_left;
	public bool resize_right;
	public bool resize_top;
	public bool resize_bottom;
	public bool resize_topLeft;
	public bool resize_topRight;
	public bool resize_bottomLeft;
	public bool resize_bottomRight;
	public bool resize_center;

	public terrain_area_class()
	{
		this.terrains = new List<terrain_class2>();
		this.tiles = new tile_class();
		this.tiles_select = new tile_class();
		this.tiles_select_link = true;
		this.center = new Vector3((float)0, (float)0, (float)0);
		this.center_synchronous = true;
		this.tile_synchronous = true;
		this.tile_position_synchronous = true;
		this.text_edit = string.Empty;
		this.remarks = new remarks_class();
		this.copy_settings = true;
		this.foldout = true;
		this.terrains_active = true;
		this.terrains_scene_active = true;
		this.terrains_foldout = true;
		this.auto_search = new auto_search_class();
		this.auto_name = new auto_search_class();
		this.scene_name = "Terrain";
		this.asset_name = "New Terrain";
		this.set_terrain_text();
	}

	public void clear()
	{
		this.terrains.Clear();
		this.set_terrain_text();
	}

	public void clear_to_one()
	{
		int count = this.terrains.Count;
		for (int i = 1; i < count; i++)
		{
			this.terrains.RemoveAt(1);
		}
		this.set_terrain_text();
	}

	public void set_terrain_text()
	{
		if (this.text_edit.Length == 0)
		{
			if (this.terrains.Count > 1)
			{
				this.text = "Terrains";
			}
			else
			{
				this.text = "Terrain";
			}
		}
		else
		{
			this.text = this.text_edit;
		}
		this.text += " (" + this.terrains.Count.ToString() + ")";
	}
}

[Serializable]
public class terrain_class2
{
	public bool active;

	public bool foldout;

	public int index;

	public int index_old;

	public bool on_row;

	public Color color_terrain;

	public Component rtp_script;

	public Texture2D[] splat_alpha;

	public Terrain terrain;

	public Transform parent;

	public string name;

	public area_class prearea;

	public float[,,] map;

	public List<splatPrototype_class> splatPrototypes;

	public splatPrototype_class colormap;

	public bool splats_foldout;

	public List<treePrototype_class> treePrototypes;

	public bool trees_foldout;

	public List<detailPrototype_class> detailPrototypes;

	public bool details_foldout;

	public List<TreeInstance> tree_instances;

	public float[] splat;

	public float[] splat_calc;

	public float[] color;

	public float[] splat_layer;

	public float[] color_layer;

	public float[] grass;

	public int heightmap_resolution_list;

	public int splatmap_resolution_list;

	public int basemap_resolution_list;

	public int detailmap_resolution_list;

	public int detail_resolution_per_patch_list;

	public Vector3 size;

	public bool size_xz_link;

	public int tile_x;

	public int tile_z;

	public Vector2 tiles;

	public Rect rect;

	public bool data_foldout;

	public Vector3 scale;

	public bool maps_foldout;

	public bool settings_foldout;

	public bool resolution_foldout;

	public bool scripts_foldout;

	public bool reset_foldout;

	public bool size_foldout;

	public int raw_file_index;

	public raw_file_class raw_save_file;

	public int heightmap_resolution;

	public int splatmap_resolution;

	public int detail_resolution;

	public int detail_resolution_per_patch;

	public int basemap_resolution;

	public bool size_synchronous;

	public bool resolutions_synchronous;

	public bool splat_synchronous;

	public bool tree_synchronous;

	public bool detail_synchronous;

	public Vector2 splatmap_conversion;

	public Vector2 heightmap_conversion;

	public Vector2 detailmap_conversion;

	public bool splat_foldout;

	public int splat_length;

	public int color_length;

	public bool tree_foldout;

	public int tree_length;

	public bool detail_foldout;

	public float detail_scale;

	public bool base_terrain_foldout;

	public bool tree_detail_objects_foldout;

	public bool wind_settings_foldout;

	public bool settings_all_terrain;

	public float heightmapPixelError;

	public int heightmapMaximumLOD;

	public bool castShadows;

	public float basemapDistance;

	public float treeDistance;

	public float detailObjectDistance;

	public float detailObjectDensity;

	public int treeMaximumFullLODCount;

	public float treeBillboardDistance;

	public float treeCrossFadeLength;

	public bool draw;

	public bool editor_draw;

	public TerrainDetail script_terrainDetail;

	public bool settings_runtime;

	public bool settings_editor;

	public float wavingGrassSpeed;

	public float wavingGrassAmount;

	public float wavingGrassStrength;

	public Color wavingGrassTint;

	public neighbor_class neighbor;

	public terrain_class2()
	{
		this.active = true;
		this.color_terrain = new Color((float)2, (float)2, (float)2, (float)1);
		this.prearea = new area_class();
		this.splatPrototypes = new List<splatPrototype_class>();
		this.colormap = new splatPrototype_class();
		this.treePrototypes = new List<treePrototype_class>();
		this.detailPrototypes = new List<detailPrototype_class>();
		this.tree_instances = new List<TreeInstance>();
		this.heightmap_resolution_list = 5;
		this.splatmap_resolution_list = 4;
		this.basemap_resolution_list = 4;
		this.size = new Vector3((float)1000, (float)250, (float)1000);
		this.size_xz_link = true;
		this.tiles = new Vector2((float)1, (float)1);
		this.data_foldout = true;
		this.resolution_foldout = true;
		this.raw_file_index = -1;
		this.raw_save_file = new raw_file_class();
		this.heightmap_resolution = 129;
		this.splatmap_resolution = 128;
		this.detail_resolution = 128;
		this.detail_resolution_per_patch = 8;
		this.basemap_resolution = 128;
		this.size_synchronous = true;
		this.resolutions_synchronous = true;
		this.splat_synchronous = true;
		this.tree_synchronous = true;
		this.detail_synchronous = true;
		this.detail_scale = (float)1;
		this.base_terrain_foldout = true;
		this.tree_detail_objects_foldout = true;
		this.wind_settings_foldout = true;
		this.settings_all_terrain = true;
		this.heightmapPixelError = (float)5;
		this.basemapDistance = (float)20000;
		this.treeDistance = (float)20000;
		this.detailObjectDistance = (float)250;
		this.detailObjectDensity = (float)1;
		this.treeMaximumFullLODCount = 50;
		this.treeBillboardDistance = (float)250;
		this.treeCrossFadeLength = (float)200;
		this.draw = true;
		this.editor_draw = true;
		this.settings_editor = true;
		this.wavingGrassSpeed = 0.5f;
		this.wavingGrassAmount = 0.5f;
		this.wavingGrassStrength = 0.5f;
		this.wavingGrassTint = new Color(0.698f, 0.6f, 0.5f);
		this.neighbor = new neighbor_class();
	}

	public void add_splatprototype(int splat_number)
	{
		this.splatPrototypes.Insert(splat_number, new splatPrototype_class());
	}

	public void erase_splatprototype(int splat_number)
	{
		if (this.splatPrototypes.Count > 0)
		{
			this.splatPrototypes.RemoveAt(splat_number);
		}
	}

	public void clear_splatprototype()
	{
		this.splatPrototypes.Clear();
	}

	public void add_treeprototype(int tree_number)
	{
		this.treePrototypes.Insert(tree_number, new treePrototype_class());
	}

	public void erase_treeprototype(int tree_number)
	{
		if (this.treePrototypes.Count > 0)
		{
			this.treePrototypes.RemoveAt(tree_number);
		}
	}

	public void clear_treeprototype()
	{
		this.treePrototypes.Clear();
	}

	public void add_detailprototype(int detail_number)
	{
		this.detailPrototypes.Insert(detail_number, new detailPrototype_class());
	}

	public void erase_detailprototype(int detail_number)
	{
		if (this.detailPrototypes.Count > 0)
		{
			this.detailPrototypes.RemoveAt(detail_number);
		}
	}

	public void clear_detailprototype()
	{
		this.detailPrototypes.Clear();
	}
}

[Serializable]
public class terrain_region_class
{
	public bool active;

	public bool foldout;

	public string text;

	public List<terrain_area_class> area;

	public int area_select;

	public int mode;

	public Rect area_size;

	public terrain_region_class()
	{
		this.active = true;
		this.foldout = true;
		this.text = "Terrain Area";
		this.area = new List<terrain_area_class>();
		this.area.Add(new terrain_area_class());
	}

	public void add_area(int index)
	{
		this.area.Insert(index, new terrain_area_class());
		this.set_area_index();
		this.set_area_text();
		this.area[index].set_terrain_text();
		this.area[index].path = Application.dataPath;
	}

	public void erase_area(int index)
	{
		this.area.RemoveAt(index);
		this.set_area_index();
		this.set_area_text();
	}

	public void set_area_index()
	{
		for (int i = 0; i < this.area.Count; i++)
		{
			this.area[i].index = i;
		}
	}

	public void set_area_text()
	{
		if (this.area.Count > 1)
		{
			this.text = "Terrain Areas";
		}
		else
		{
			this.text = "Terrain Area";
		}
	}
}

[Serializable]
public class tile_class
{
	public int x;

	public int y;

    public tile_class() { }
	
	public tile_class(int x1, int y2)
	{
		this.x = x1;
		this.y = y2;
	}

	public void reset()
	{
		this.x = 0;
		this.y = 0;
	}
}

[Serializable]
public class treePrototype_class
{
	public GameObject prefab;

	public Texture2D texture;

	public float bendFactor;

	public bool foldout;

	public treePrototype_class()
	{
		this.bendFactor = 0.3f;
	}
}
#endif

    [Serializable]
public class map_pixel_class
{
    public double x;

    public double y;

    public void reset()
    {
        this.x = (double)0;
        this.y = (double)0;
    }
}