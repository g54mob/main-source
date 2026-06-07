const fs = require('fs');
const path = require('path');

const targetDir = path.resolve(__dirname, process.argv[2] || '.');

function walkAndStub(dir) {
  const entries = fs.readdirSync(dir, { withFileTypes: true });

  for (const entry of entries) {
    const fullPath = path.join(dir, entry.name);

    if (entry.isDirectory()) {
      walkAndStub(fullPath);
    } else if (entry.isFile()) {
      if (entry.name.endsWith('.stub')) continue;

      const stats = fs.statSync(fullPath);
      const sizeMB = (stats.size / (1024 * 1024)).toFixed(2);
      fs.writeFileSync(fullPath + '.stub', `${sizeMB} MB\n`, 'utf8');
    }
  }
}

walkAndStub(targetDir);
console.log(`Done. Stubs created in: ${path.relative(__dirname, targetDir) || '.'}`);
