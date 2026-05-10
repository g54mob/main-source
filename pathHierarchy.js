/**
 * pathHierarchy.js
 * ─────────────────────────────────────────────────────────────
 * Scans a given subfolder recursively and writes every file
 * (relative path from root + size) into a .txt file at the
 * root folder, named after the scanned folder.
 *
 *   node pathHierarchy.js "Scripts/"
 *   → writes  Scripts.txt  in the root folder
 *
 *   node pathHierarchy.js "Assets/Audio"
 *   → writes  Audio.txt  in the root folder
 *
 * No external dependencies — Node.js built-ins only.
 * ─────────────────────────────────────────────────────────────
 */

const fs   = require('fs');
const path = require('path');

// ── Args ──────────────────────────────────────────────────────
const SCRIPT_NAME = path.basename(__filename);
const TARGET_ARG  = process.argv[2];

if (!TARGET_ARG) {
  console.error(`\n❌  No folder specified.\n`);
  console.error(`    Usage: node ${SCRIPT_NAME} "Scripts/"\n`);
  process.exit(1);
}

const ROOT        = process.cwd();
const TARGET_FULL = path.resolve(ROOT, TARGET_ARG);

if (!fs.existsSync(TARGET_FULL)) {
  console.error(`\n❌  Folder not found: "${TARGET_ARG}"\n`);
  console.error(`    Resolved to: ${TARGET_FULL}\n`);
  process.exit(1);
}

if (!fs.statSync(TARGET_FULL).isDirectory()) {
  console.error(`\n❌  "${TARGET_ARG}" is a file, not a folder.\n`);
  process.exit(1);
}

// Output txt named after the deepest folder segment, written at root
const FOLDER_NAME = path.basename(TARGET_FULL);
const OUT_PATH    = path.join(ROOT, `entire-${FOLDER_NAME}.stub`);

// ── Helpers ───────────────────────────────────────────────────
const toRelPath = (p) => path.relative(ROOT, p).replace(/\\/g, '/');

function humanSize(bytes) {
  if (bytes >= 1073741824) return `${(bytes / 1073741824).toFixed(3)} GB`;
  if (bytes >= 1048576)    return `${(bytes / 1048576).toFixed(2)} MB`;
  if (bytes >= 1024)       return `${(bytes / 1024).toFixed(1)} KB`;
  return `${bytes} B`;
}

// ── Walk ──────────────────────────────────────────────────────
function walkDir(dir, results = []) {
  let entries;
  try { entries = fs.readdirSync(dir, { withFileTypes: true }); }
  catch { return results; }

  for (const entry of entries) {
    const full = path.join(dir, entry.name);
    if (entry.isDirectory()) {
      walkDir(full, results);
    } else if (entry.isFile()) {
      try {
        const { size } = fs.statSync(full);
        results.push({ full, size });
      } catch { /* permission denied — skip */ }
    }
  }

  return results;
}

// ── Main ──────────────────────────────────────────────────────
function main() {
  const divider = '─'.repeat(65);

  console.log(`\n📂  pathHierarchy.js`);
  console.log(`    Scanning: ${toRelPath(TARGET_FULL)}/\n`);

  const files = walkDir(TARGET_FULL);
  const rows  = files.map(f => ({ rel: toRelPath(f.full), human: humanSize(f.size), size: f.size }));

  // ── Build aligned text content ────────────────────────────────
  const maxLen     = rows.length ? Math.max(...rows.map(r => r.rel.length)) : 0;
  const totalBytes = rows.reduce((s, r) => s + r.size, 0);

  const lines = [];
  lines.push(divider);
  lines.push(`Folder : ${toRelPath(TARGET_FULL)}/`);
  lines.push(`Files  : ${rows.length}`);
  lines.push(`Total  : ${humanSize(totalBytes)}`);
  lines.push(divider);
  lines.push('');

  if (rows.length === 0) {
    lines.push('(no files found)');
  } else {
    for (const row of rows) {
      lines.push(`${row.rel.padEnd(maxLen + 2)}${row.human}`);
    }
  }

  lines.push('');

  // ── Write file ────────────────────────────────────────────────
  fs.writeFileSync(OUT_PATH, lines.join('\n'), 'utf8');

  console.log(`    ✅ Written → ${FOLDER_NAME}.txt`);
  console.log(`    Files : ${rows.length}`);
  console.log(`    Total : ${humanSize(totalBytes)}\n`);
}

main();
